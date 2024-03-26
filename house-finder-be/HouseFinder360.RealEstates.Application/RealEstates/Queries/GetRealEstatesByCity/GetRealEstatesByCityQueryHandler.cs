using HouseFinder360.RealEstates.Application.Common.Interfaces.Persistence.Generic;
using HouseFinder360.RealEstates.Application.Common.Pagination;
using HouseFinder360.RealEstates.Application.RealEstates.Dto;
using HouseFinder360.RealEstates.Application.RealEstates.Mapper;
using HouseFinder360.RealEstates.Application.RealEstates.Queries.GetUserProperties;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HouseFinder360.RealEstates.Application.RealEstates.Queries.GetRealEstatesByCity;

public record GetRealEstatesByCityQuery(string City, Pagination Pagination) : IRequest<PagedResponse<PropertyResponse>>;

public class GetRealEstatesByCityQueryHandler : IRequestHandler<GetRealEstatesByCityQuery, PagedResponse<PropertyResponse>>
{
    private readonly IDbContext _dbContext;

    public GetRealEstatesByCityQueryHandler(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task<PagedResponse<PropertyResponse>> Handle(GetRealEstatesByCityQuery request, CancellationToken cancellationToken)
    {
        var query = _dbContext.Properties.AsQueryable();
        request.Pagination.TotalItems = await query.CountAsync(cancellationToken);

        var propertyList = await query
            .Include(x => x.Address)
            .OrderByDescending(x => x.Price.Value)
            .Where(x => x.Address.City.Name == request.City)
            .Skip((request.Pagination.CurrentPage - 1) * request.Pagination.PageSize)
            .Take(request.Pagination.PageSize)
            .Include(x => x.Photos)
            .ToListAsync(cancellationToken);
        var mapped = propertyList.Select(PropertyMapper.MapProperty);

        return new PagedResponse<PropertyResponse>
        {
            Data = mapped,
            Pagination = request.Pagination
        };
    }
}
