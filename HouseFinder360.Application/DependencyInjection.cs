using HouseFinder360.Application.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace HouseFinder360.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        return services;
    }
}