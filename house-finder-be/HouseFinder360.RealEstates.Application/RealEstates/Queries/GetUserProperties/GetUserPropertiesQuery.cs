using HouseFinder360.RealEstates.Application.RealEstates.Dto;
using MediatR;

namespace HouseFinder360.RealEstates.Application.RealEstates.Queries.GetUserProperties;

public record GetUserPropertiesQuery(Guid UserId) : IRequest<IEnumerable<PropertyResponse>>;
