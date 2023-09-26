namespace HouseFinder360.Api.Endpoints;

public static class ErrorsModule
{
    public static IEndpointRouteBuilder MapErrorsModule(this IEndpointRouteBuilder app)
    {
        app.MapGet("/errors", () => Results.Problem());
        return app;
    }
}