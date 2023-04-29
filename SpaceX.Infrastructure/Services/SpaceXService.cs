using System;
using System.Net.Http;
using SpaceX.Domain;
using SpaceX.Domain.Common;

namespace SpaceX.Infrastructure.Services
{
	public class SpaceXService : ISpaceXService
	{
		public SpaceXService(IHttpClientFactory httpClientFacotry)
		{
            HttpClientFacotry = httpClientFacotry;
        }

        public IHttpClientFactory HttpClientFacotry { get; }

        public Task<List<Launch>> GetLaunches(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}

