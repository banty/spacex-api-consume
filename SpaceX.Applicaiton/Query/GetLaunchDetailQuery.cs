using System;
using MediatR;
using SpaceX.Domain;

namespace SpaceX.Applicaiton.Query
{
	public class GetLaunchDetailQuery:IRequest<Launch>
	{
		public string Id { get; set; }
		public GetLaunchDetailQuery(string id)
		{
			Id = id;
		}
	}
}

