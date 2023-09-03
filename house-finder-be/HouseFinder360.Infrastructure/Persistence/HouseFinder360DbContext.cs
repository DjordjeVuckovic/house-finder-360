using HouseFinder360.Application.Common.Interfaces.Persistence.Generic;
using HouseFinder360.Domain.Properties;
using HouseFinder360.Domain.Users;
using HouseFinder360.Infrastructure.Extensions;
using HouseFinder360.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace HouseFinder360.Infrastructure.Persistence;

public class HouseFinder360DbContext: DbContext,IDbContext
{
    public HouseFinder360DbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<RealEstate> Properties { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(HouseFinder360DbContext).Assembly);
        base.OnModelCreating(modelBuilder);

    }
}