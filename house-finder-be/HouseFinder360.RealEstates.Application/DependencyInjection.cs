using System.Reflection;
using HouseFinder360.RealEstates.Application.Common.Behaviours;
using HouseFinder360.RealEstates.Application.Common.BlobStorage;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace HouseFinder360.RealEstates.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
        services.AddScoped<BlobHandler>();
        return services;
    }
}