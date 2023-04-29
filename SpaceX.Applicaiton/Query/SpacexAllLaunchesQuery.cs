using System;
using MediatR;
using SpaceX.Domain;

namespace SpaceX.Applicaiton.Query
{
	public class SpacexAllLaunchesQuery : IRequest<List<Launch>>
	{
		public SpacexAllLaunchesQuery(string filter)
		{
            Filter = filter;
        }

        public string Filter { get; }
    }
}

