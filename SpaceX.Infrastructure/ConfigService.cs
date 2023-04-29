using System;
using Microsoft.Extensions.DependencyInjection;
using SpaceX.Domain.Common;
using SpaceX.Infrastructure.Services;

namespace SpaceX.Infrastructure
{
	public static class ConfigService
	{
		public static IServiceCollection InfrastructureService(this IServiceCollection services)
		{
			services.AddHttpClient<ISpaceXService, SpaceXService>();
			return services;
		}
	}
}

