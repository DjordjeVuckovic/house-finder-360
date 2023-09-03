using HouseFinder360.Application.Common.Pagination;
using HouseFinder360.Application.Property.Dto;
using MediatR;

namespace HouseFinder360.Application.Property.Queries.GetPropertiesPaginite;

public record GetPropertiesPaginiteQuery(Pagination Pagination) : IRequest<PagedResponse<PropertyResponse>>;