using HouseFinder360.RealEstates.Domain.RealEstates;
using Microsoft.EntityFrameworkCore;

namespace HouseFinder360.RealEstates.Application.Common.Interfaces.Persistence.Generic;

public interface IDbContext
{
    public DbSet<RealEstate> Properties { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}