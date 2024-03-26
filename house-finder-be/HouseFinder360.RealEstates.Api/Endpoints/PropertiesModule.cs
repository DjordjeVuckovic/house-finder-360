using System.Text.Json;
using HouseFinder360.RealEstates.Api.Dto.Requests.Property;
using HouseFinder360.RealEstates.Api.Extensions;
using HouseFinder360.RealEstates.Application.Common.Pagination;
using HouseFinder360.RealEstates.Application.RealEstates.Commands;
using HouseFinder360.RealEstates.Application.RealEstates.Queries.GetPropertiesPaginite;
using HouseFinder360.RealEstates.Application.RealEstates.Queries.GetRealEstatesByCity;
using HouseFinder360.RealEstates.Application.RealEstates.Queries.GetUserProperties;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace HouseFinder360.RealEstates.Api.Endpoints;

internal static class PropertiesModule
{

    internal static void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("api/v1/properties", async (
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
                    Errors = new[] { "Cannot find property form field!" }
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
                    Errors = new[] { "Wrong request format!" }
                });
            }
            var mapped = mapper.Map<CreatePropertyCommand>(salePropertyRequest);
            mapped.Photos = photos;
            var result = await sender.Send(mapped);
            return result.IsFailed
                ? Results.BadRequest(result.Errors.ToResponse())
                : Results.Ok();
        }).RequireAuthorization();

        app.MapGet("api/v1/properties", async (
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

        app.MapGet("api/v1/properties/{userId:guid}", async (
            Guid userId,
            ISender sender) =>
        {
            var properties = await sender.Send(
                new GetUserPropertiesQuery(userId));
            return Results.Ok(properties);
        }).RequireAuthorization();

        app.MapGet("api/v1/properties/city/{name}", async (
            int currentPage,
            int pageSize,
            string name,
            ISender sender) =>
        {
            var pagination = new Pagination
            {
                CurrentPage = currentPage,
                PageSize = pageSize
            };
            var properties = await sender
                .Send(new GetRealEstatesByCityQuery(name, pagination));
            return Results.Ok(properties);
        });
    }
}
