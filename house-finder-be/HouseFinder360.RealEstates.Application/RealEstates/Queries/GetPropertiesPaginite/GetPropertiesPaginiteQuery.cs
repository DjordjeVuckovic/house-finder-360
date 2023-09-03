using HouseFinder360.RealEstates.Application.Common.Pagination;
using HouseFinder360.RealEstates.Application.RealEstates.Dto;
using MediatR;

namespace HouseFinder360.RealEstates.Application.RealEstates.Queries.GetPropertiesPaginite;

public record GetPropertiesPaginiteQuery(Pagination Pagination) : IRequest<PagedResponse<PropertyResponse>>;