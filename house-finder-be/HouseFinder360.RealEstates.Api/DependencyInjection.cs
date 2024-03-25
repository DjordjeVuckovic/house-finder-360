using HouseFinder360.Application.BuildingBlocks.Common.Interfaces;
using HouseFinder360.RealEstates.Api.Mapping;
using HouseFinder360.RealEstates.Application;
using HouseFinder360.RealEstates.Infrastructure;
using HouseFinder360.RealEstates.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HouseFinder360.RealEstates.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddRealEstateModule(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.AddMapping();
        services
            .AddInfrastructure(configuration)
            .AddApplication();
        return services;
    }
}
