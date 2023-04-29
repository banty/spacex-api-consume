using System;
using MediatR;
using SpaceX.Domain;
using SpaceX.Domain.Common;

namespace SpaceX.Applicaiton.Query
{
	public class SpacexAllLaunchesQueryHandler :IRequestHandler<SpacexAllLaunchesQuery,List<Launch>>
	{
        private readonly ISpaceXService spaceXService;

        public SpacexAllLaunchesQueryHandler(ISpaceXService spaceXService)
		{
            this.spaceXService = spaceXService;
        }

        public async Task<List<Launch>> Handle(SpacexAllLaunchesQuery request, CancellationToken cancellationToken)
        {
            return await spaceXService.GetLaunches(cancellationToken);
        }
    }
}

