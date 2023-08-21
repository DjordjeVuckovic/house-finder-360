using HouseFinder360.Domain.Property;
using HouseFinder360.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace HouseFinder360.Application.Common.Interfaces.Persistence.Generic;

public interface IDbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Domain.Property.Property> Properties { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}