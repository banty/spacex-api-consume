using System;
using MediatR;
using SpaceX.Domain;
using SpaceX.Domain.Common;
using MongoDB.Bson;
using SpaceX.Applicaiton.Exceptions;

namespace SpaceX.Applicaiton.Query
{
	public class GetLaunchesQueryHandler :IRequestHandler<GetLaunchesQuery,List<Launch>>
	{
        private readonly ISpacexService spaceXService;

        public GetLaunchesQueryHandler(ISpacexService spacexService)
		{
            this.spaceXService = spacexService;
        }

        public async Task<List<Launch>> Handle(GetLaunchesQuery request, CancellationToken cancellationToken)
        {
           
            var result= await spaceXService.GetLaunches(request.Filter,  cancellationToken);

            if (result == null) throw new NotFoundExcption("No lauch found.");
            
            return result.ToList();
        }
    }
}

