using HouseFinder360.RealEstates.Application.Common.Interfaces.Persistence.Generic;
using HouseFinder360.RealEstates.Domain.RealEstates;
using Microsoft.EntityFrameworkCore;

namespace HouseFinder360.RealEstates.Infrastructure.Persistence;

public class HouseFinder360DbContext : DbContext, IDbContext
{
    public HouseFinder360DbContext(DbContextOptions<HouseFinder360DbContext> options) : base(options)
    {
    }

    public DbSet<RealEstate> Properties { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(HouseFinder360DbContext).Assembly);
        modelBuilder.HasDefaultSchema(Schema.PropertiesSchema);
        base.OnModelCreating(modelBuilder);

    }
}
