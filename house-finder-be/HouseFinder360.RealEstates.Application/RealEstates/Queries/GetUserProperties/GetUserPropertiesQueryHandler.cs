using HouseFinder360.RealEstates.Application.Common.Interfaces.Persistence.Generic;
using HouseFinder360.RealEstates.Application.RealEstates.Dto;
using HouseFinder360.RealEstates.Application.RealEstates.Mapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HouseFinder360.RealEstates.Application.RealEstates.Queries.GetUserProperties;

public class GetUserPropertiesQueryHandler : IRequestHandler<GetUserPropertiesQuery, IEnumerable<PropertyResponse>>
{
    private readonly IDbContext _dbContext;

    public GetUserPropertiesQueryHandler(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<PropertyResponse>> Handle(GetUserPropertiesQuery request, CancellationToken cancellationToken)
    {
        var properties = await _dbContext.Properties
            .Where(x => x.UserId == request.UserId)
            .Include(x => x.Address)
            .Include(x => x.Photos)
            .ToListAsync(cancellationToken);
        var mapped = properties.Select(PropertyMapper.MapProperty);
        return mapped;
    }
}