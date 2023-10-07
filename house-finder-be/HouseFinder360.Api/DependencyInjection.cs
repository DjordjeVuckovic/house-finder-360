using HouseFinder360.Api.Services;
using HouseFinder360.Application.BuildingBlocks.Common.Interfaces;

namespace HouseFinder360.Api;

internal static class DependencyInjection
{
    public static IServiceCollection AddBootstrapper(this IServiceCollection services)
    {
        services.AddScoped<ICurrentUserService, CurrentUserService>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        return services;
    }
}