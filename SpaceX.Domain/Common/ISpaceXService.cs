using System;
namespace SpaceX.Domain.Common
{
	public interface ISpaceXService
	{
		Task<List<Launch>> GetLaunches(CancellationToken cancellationToken=default);
	}
}

