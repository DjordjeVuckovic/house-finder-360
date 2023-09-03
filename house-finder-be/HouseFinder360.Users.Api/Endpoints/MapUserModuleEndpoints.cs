using Microsoft.AspNetCore.Routing;

namespace HouseFinder360.Users.Api.Endpoints;

public static class MapUserModuleEndpoints
{
    public static IEndpointRouteBuilder MapUserModule(this IEndpointRouteBuilder app)
    {
        UsersModule.AddRoutes(app);
        return app;
    } 
}