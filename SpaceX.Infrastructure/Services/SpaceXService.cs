using System;
using System.Net.Http;

using Microsoft.Net.Http.Headers;
using SpaceX.Domain;
using SpaceX.Domain.Common;
using System.Net.Http.Json;
using SpaceX.Applicaiton.Exceptions;

namespace SpaceX.Infrastructure.Services
{
	public class SpaceXService : ISpacexService
	{

        public SpaceXService(IHttpClientFactory clientFactory)
		{

            this.clientFactory = clientFactory;
            
        }

        public IHttpClientFactory clientFactory { get; }

        public async Task<List<Launch>?> GetLaunches(string filter="",CancellationToken cancellationToken=default)
            => await GetData(cancellationToken,filter);

       

        private async Task<List<Launch>?> GetData(CancellationToken cancellationToken,string filter="")
        {

            var request = new HttpRequestMessage(HttpMethod.Get, filter+"?id=true");

            var client = clientFactory.CreateClient("spacex");

            try
            {
                var response = await client.SendAsync(request);
                return await response.Content.ReadFromJsonAsync<List<Launch>>();
            }
            catch (Exception ex)
            {
                throw new Exception("Unale to reterive data", ex);
            }
        }
        public async Task<Launch?> GetSingleLaunch(string id, CancellationToken cancellationToken)
        {

            var request = new HttpRequestMessage(HttpMethod.Get, $"?flight_id={id}&id=true");

            var client = clientFactory.CreateClient("spacex");

            try
            {
                var response = await client.SendAsync(request);
                var result= await response.Content.ReadFromJsonAsync<List<Launch>>();
                if (result == null) throw new NotFoundExcption();

                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new NotFoundExcption("Unale to reterive data", ex);
            }
        }



    }
}

