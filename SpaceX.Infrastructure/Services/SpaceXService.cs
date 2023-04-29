using System;
using System.Net.Http;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using SpaceX.Domain;
using SpaceX.Domain.Common;

namespace SpaceX.Infrastructure.Services
{
	public class SpaceXService : ISpaceXService
	{
        private readonly IConfiguration configuration;

        public SpaceXService(IHttpClientFactory httpClientFacotry,IConfiguration configuration)
		{
            
            httpClient = httpClientFacotry.CreateClient();
            this.configuration = configuration;
        }

        public HttpClient httpClient { get; }

        public async Task<List<Launch>> GetLaunches(CancellationToken cancellationToken = default)
        {
            httpClient.BaseAddress=new Uri(configuration.GetSection("SpacexUri").Value??string.Empty);
           
            var response = await httpClient.GetAsync("/launches");

            response.EnsureSuccessStatusCode();

            var totalItem=response.Headers.GetValues("spacex-api-count").First();
            using var conteStream = await response.Content.ReadAsStreamAsync();

            var result = JsonSerializer.Deserialize<IEnumerable<Launch>>(conteStream);

            return result.ToList();
        }
    }
}

