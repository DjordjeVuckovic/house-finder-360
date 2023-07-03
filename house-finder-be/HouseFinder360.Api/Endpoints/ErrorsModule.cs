using Carter;

namespace HouseFinder360.Api.Endpoints;

public class ErrorsModule : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/errors", () => Results.Problem());
    }
}