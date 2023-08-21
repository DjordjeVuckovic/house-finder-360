using System.Reflection;
using HouseFinder360.Application.Common.Behaviours;
using HouseFinder360.Application.Common.BlobStorage;
using HouseFinder360.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using WeDoHr.ProjectManagement.Application.Common.Behaviours;

namespace HouseFinder360.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
        services.AddTransient<IPasswordHasher<User>, PasswordHasher<User>>();
        services.AddScoped<BlobHandler>();
        return services;
    }
}