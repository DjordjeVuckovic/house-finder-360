using FluentValidation;
using FluentValidation.AspNetCore;
using HouseFinder360.Api.Services;
using HouseFinder360.Application.BuildingBlocks.Common.Interfaces;

namespace HouseFinder360.Api;

internal static class DependencyInjection
{
    public static IServiceCollection AddBootstrapper(this IServiceCollection services)
    {
        services.AddValidation();
        services.AddScoped<ICurrentUserService, CurrentUserService>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        return services;
    }

    private static void AddValidation(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining(typeof(DependencyInjection));
        services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
    }
}