using SpaceX.Infrastructure;
using SpaceX.Applicaiton;
using Microsoft.Extensions.Configuration;
using SpaceX.Domain.Common;
using SpaceX.Infrastructure.Services;
using SpaceX.Applicaiton.Query;
using System.Reflection;
using FluentValidation;
using SpaceX.Infrastructure.Middleware;
using Microsoft.OpenApi.Models;
using Polly;
using Polly.Extensions.Http;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(swag =>
        {
            swag.SwaggerDoc("v1", new OpenApiInfo
            {
                Contact = new OpenApiContact() { Name = "Developer", Email = "developer@mail.com" },
                Description = "SpaceX data extract API",
                License = new OpenApiLicense() { Name = "MIT" },
                Title = "SpaceX data extract API version 3",
                Version = "3"

            });

        });
        builder.Services.AddLogging();
        builder.Services.AddMediatR(t => t.RegisterServicesFromAssemblyContaining<GetLaunchesQueryHandler>());

        builder.Services.AddHttpClient("spacex", t =>
        {
            t.BaseAddress = new Uri(builder.Configuration.GetValue<string>("SpacexUri"));
        })
        .SetHandlerLifetime(TimeSpan.FromMinutes(5))
        .AddPolicyHandler(ReteryPolicyHandler)
        .AddPolicyHandler(CircuitBreakerHandler);

        builder.Services.AddScoped<ISpacexService, SpaceXService>();
        builder.Services.AddScoped<ExceptionMiddleware>();

        builder.Services.AddHealthChecks();
        builder.Services.AddCors();
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseCors(t =>
        {
            t.AllowAnyHeader();
            t.AllowAnyMethod();
            t.AllowAnyOrigin();
        });
        app.UseAuthorization();
        app.UseMiddleware<ExceptionMiddleware>();
        app.MapControllers();
        app.UseHealthChecks("/hc");

       
        app.Run();
    }

    private static IAsyncPolicy<HttpResponseMessage> ReteryPolicyHandler(HttpRequestMessage arg)
    {
        return HttpPolicyExtensions.HandleTransientHttpError()
               .OrResult(res => res.StatusCode == System.Net.HttpStatusCode.NotFound)
               .WaitAndRetryAsync(4, (retryAttemp => TimeSpan.FromSeconds(Math.Pow(2,retryAttemp))));
    }

    private static IAsyncPolicy<HttpResponseMessage> CircuitBreakerHandler(HttpRequestMessage arg)
    {
        return HttpPolicyExtensions.HandleTransientHttpError()
               .OrResult(res => res.StatusCode == System.Net.HttpStatusCode.NotFound)
               .CircuitBreakerAsync(4, TimeSpan.FromSeconds(30));
               
    }
}