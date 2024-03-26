using Microsoft.AspNetCore.Routing;

namespace HouseFinder360.RealEstates.Api.Endpoints;

public static class MapEndpointsRealEstateModule
{
    public static IEndpointRouteBuilder MapRealEstateModule(this IEndpointRouteBuilder app)
    {
        PropertiesModule.AddRoutes(app);
        return app;
    }
}
