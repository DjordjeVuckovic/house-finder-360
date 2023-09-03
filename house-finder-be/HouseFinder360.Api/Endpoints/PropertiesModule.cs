using System.Text.Json;
using Carter;
using HouseFinder360.Api.Dto.Requests.Property;
using HouseFinder360.Api.Extensions;
using HouseFinder360.Application.Common.Pagination;
using HouseFinder360.Application.Property.Commands;
using HouseFinder360.Application.Property.Queries.GetPropertiesPaginite;
using HouseFinder360.Application.Property.Queries.GetUserProperties;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HouseFinder360.Api.Endpoints;

public class PropertiesModule : CarterModule
{
    public PropertiesModule() : base("api/v1/properties")
    {
    }

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("", async (
            [FromForm] IFormFileCollection photos,
            HttpContext context,
            ISender sender,
            IMapper mapper) =>
        {
            var propertyString = context.Request.Form["property"];
            if (string.IsNullOrWhiteSpace(propertyString))
            {
                return Results.BadRequest(new ErrorResponse
                {
                    Errors = new[]{"Cannot find property form field!"}
                });
            }
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            var salePropertyRequest = JsonSerializer.Deserialize<SalePropertyRequest>(propertyString!, options);
            if (salePropertyRequest is null)
            {
                return Results.BadRequest(new ErrorResponse
                {
                    Errors = new[]{"Wrong request format!"}
                });
            }
            var mapped = mapper.Map<CreateSalePropertyCommand>(salePropertyRequest);
            mapped.Photos = photos;
            var result = await sender.Send(mapped);
            return result.IsFailed 
                ? Results.BadRequest(result.Errors.ToResponse())
                : Results.Ok();
        });
        
        app.MapGet("", async (
            int currentPage,
            int pageSize,
            ISender sender) =>
        {
            var properties = await sender.Send(
                new GetPropertiesPaginiteQuery(new Pagination
            {
                CurrentPage = currentPage,
                PageSize = pageSize
            }));
            return Results.Ok(properties);
        });
        app.MapGet("{userId:guid}", async (
            Guid userId,
            ISender sender) =>
        {
            var properties = await sender.Send(
                new GetUserPropertiesQuery(userId));
            return Results.Ok(properties);
        }).RequireAuthorization();
    }
}