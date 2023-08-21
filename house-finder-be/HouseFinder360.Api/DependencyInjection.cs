using FluentValidation;
using FluentValidation.AspNetCore;
using HouseFinder360.Api.Mapping;
using HouseFinder360.Api.Services;
using HouseFinder360.Application.Common.Interfaces.Authentication;

namespace HouseFinder360.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddMapping();
        services.AddValidation();
        services.AddScoped<ICurrentUserService, CurrentUserService>();
        return services;
    }

    private static void AddValidation(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining(typeof(DependencyInjection));
        services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
        // services.AddScoped(typeof(IPipelineBehavior<,>)
        //     , typeof(ValidationBehavior<,>));
    }
}