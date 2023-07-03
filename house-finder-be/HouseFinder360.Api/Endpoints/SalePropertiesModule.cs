using Carter;
using HouseFinder360.Api.Dto.Requests.Property;

namespace HouseFinder360.Api.Endpoints;

public class SalePropertiesModule : CarterModule
{
    public SalePropertiesModule() : base("api/v1/sale-properties")
    {
    }

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("", async (SalePropertyRequest salePropertyRequest) =>
        {
            await Task.CompletedTask;
            return Results.Ok(salePropertyRequest);
        });
    }
}