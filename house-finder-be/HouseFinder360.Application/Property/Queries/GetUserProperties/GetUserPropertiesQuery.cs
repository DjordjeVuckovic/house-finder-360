using HouseFinder360.Application.Property.Dto;
using MediatR;

namespace HouseFinder360.Application.Property.Queries.GetUserProperties;

public record GetUserPropertiesQuery(Guid UserId): IRequest<IEnumerable<PropertyResponse>>;