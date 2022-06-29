using Fieldlevel.Application.Common.Interfaces;
using Fieldlevel.Infrastructure.Persistence;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Fieldlevel.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IMemoryCache, MemoryCache>();
        services.AddTransient<IUserPostWebClient, UserPostWebClient>();

        return services;
    }
}
