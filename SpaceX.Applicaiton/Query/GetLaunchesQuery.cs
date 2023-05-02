using System;
using MediatR;
using SpaceX.Domain;

namespace SpaceX.Applicaiton.Query
{
	public class GetLaunchesQuery : IRequest<List<Launch>>
	{
		public GetLaunchesQuery(string filter="")
		{
            Filter = filter;
        }

        public string Filter { get; }
    }
}

