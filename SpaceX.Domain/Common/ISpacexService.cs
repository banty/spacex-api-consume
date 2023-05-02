using System;
namespace SpaceX.Domain.Common
{
	public interface ISpacexService
	{
		Task<List<Launch>?> GetLaunches(string filter="",CancellationToken cancellationToken=default);

        Task<Launch?> GetSingleLaunch(string id, CancellationToken cancellationToken);


    }
}

