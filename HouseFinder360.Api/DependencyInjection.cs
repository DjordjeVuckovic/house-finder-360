using FluentValidation;
using FluentValidation.AspNetCore;
using HouseFinder360.Api.Common;
using HouseFinder360.Api.Mapping;

namespace HouseFinder360.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddMapping();
        services.AddControllers();
        services.AddSwaggerDocument();
        services.AddValidation();
        return services;
    }

    private static IServiceCollection AddValidation(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<IAssemblyMarker>();
        services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
        // services.AddScoped(typeof(IPipelineBehavior<,>)
        //     , typeof(ValidationBehavior<,>));
        return services;
    }
}