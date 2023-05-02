using System;
using MediatR;
using MongoDB.Bson;
using SpaceX.Applicaiton.Exceptions;
using SpaceX.Domain;
using SpaceX.Domain.Common;

namespace SpaceX.Applicaiton.Query
{
	public class GetLaunchDetailQueryHandler:IRequestHandler<GetLaunchDetailQuery,Launch?>
	{
        private readonly ISpacexService spaceXService;

        public GetLaunchDetailQueryHandler(ISpacexService spaceXService)
		{
            this.spaceXService = spaceXService;
        }

        public async Task<Launch?> Handle(GetLaunchDetailQuery request, CancellationToken cancellationToken)
        {
            ObjectId id;
            if (!ObjectId.TryParse(request.Id, out id))
                throw new InvalidIdException();

           return await spaceXService.GetSingleLaunch(request.Id, cancellationToken);
        }
    }
}

