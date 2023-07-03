using HouseFinder360.Domain.Property;
using HouseFinder360.Domain.User;
using Microsoft.EntityFrameworkCore;

namespace HouseFinder360.Application.Common.Interfaces.Persistence.Generic;

public interface IDbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<SaleProperty> SaleProperties { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}