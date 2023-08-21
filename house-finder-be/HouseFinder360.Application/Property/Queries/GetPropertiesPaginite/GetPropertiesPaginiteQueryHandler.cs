using HouseFinder360.Application.Common.Dtos.Shared;
using HouseFinder360.Application.Common.Interfaces.Persistence.Generic;
using HouseFinder360.Application.Property.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HouseFinder360.Application.Property.Queries.GetPropertiesPaginite;

public class GetPropertiesPaginiteQueryHandler : IRequestHandler<GetPropertiesPaginiteQuery,IEnumerable<PropertyResponse>>
{
    private readonly IDbContext _dbContext;

    public GetPropertiesPaginiteQueryHandler(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<PropertyResponse>> Handle(GetPropertiesPaginiteQuery request, CancellationToken cancellationToken)
    {
        var propertyList = await _dbContext.Properties
            .Include(x => x.Address)
            .ToListAsync(cancellationToken);
        /*var query = _dbContext.SaleProperties.AsQueryable();
        request.Pagination.TotalItems = await query.CountAsync(cancellationToken);

        var propertyList = await query
            .Skip((request.Pagination.CurrentPage - 1) * request.Pagination.PageSize)
            .Take(request.Pagination.PageSize)
            .Include(x => x.Address)
            .OrderBy(x => x.Price.Value)
            .ToListAsync(cancellationToken);*/
        var mapped = propertyList.Select(x => new PropertyResponse
        {
            Title = x.Title,
            Price = x.Price.Value,
            Address = new AddressDto(
                x.Address.Street.Name,
                x.Address.City.Name,
                x.Address.Country,
                x.Address.Street.Longitude,
                x.Address.Street.Latitude,
                x.Address.Street.Longitude,
                x.Address.City.Latitude),
            BedroomsNumber = x.NumberOfRooms,
            BathroomsNumber = x.AdditionalInfo.BathroomNumber,
            Area = x.Area.SquadMeter,
            PropertyType = x.PropertyType.TypeOfPropertyToString(),
            Kind = "For sale"
        });
        return mapped;
    }
}