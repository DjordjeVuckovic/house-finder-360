using FluentValidation;
using HouseFinder360.RealEstates.Application.Common.BlobStorage;
using Microsoft.Extensions.DependencyInjection;

namespace HouseFinder360.RealEstates.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(typeof(IRealEstateMarkerApplication).Assembly));
        services.AddScoped<BlobHandler>();
        return services;
    }
}
