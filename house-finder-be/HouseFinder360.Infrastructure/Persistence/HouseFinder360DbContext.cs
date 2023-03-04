using HouseFinder360.Domain.Property;
using HouseFinder360.Domain.User;
using Microsoft.EntityFrameworkCore;

namespace HouseFinder360.Infrastructure.Persistence;

public class HouseFinder360DbContext:DbContext
{
    public HouseFinder360DbContext(DbContextOptions<HouseFinder360DbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<SaleProperty> SaleProperties { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfigurationsFromAssembly(typeof(HouseFinder360DbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}