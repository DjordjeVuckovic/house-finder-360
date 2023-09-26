using HouseFinder360.Users.Api.Mappings;
using HouseFinder360.Users.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HouseFinder360.Users.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddUsersModule(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddUsersInfrastructure(configuration);
        services.AddMapping();
        return services;
    }
}