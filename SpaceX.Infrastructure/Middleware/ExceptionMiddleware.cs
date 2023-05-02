using System;
using System.Net;
using Microsoft.Extensions.Logging;
using SpaceX.Applicaiton.Exceptions;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace SpaceX.Infrastructure.Middleware
{
	public class ExceptionMiddleware:IMiddleware
	{
        private readonly ILogger<ExceptionMiddleware> logger;

        public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger)
		{
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
			try
			{
				await next(context);
			}
			catch (Exception ex)
			{ string message = "Internal server error";
				var response = context.Response;
				switch(ex)
				{
					case NotFoundExcption:
						response.StatusCode = (int)HttpStatusCode.NotFound;
						message = ex.Message;
						
						break;
					case InvalidIdException:
						response.StatusCode = (int)HttpStatusCode.NotFound;
						message = ex.Message;
						break;
					default:
						response.StatusCode = (int)HttpStatusCode.InternalServerError;
						break;
				}
				logger.LogError(message, response.StatusCode);
				response.ContentType = "application/json";
				string json = JsonSerializer.Serialize(new { message = message });
				await response.WriteAsync(json);

			}
        }
    }
}

