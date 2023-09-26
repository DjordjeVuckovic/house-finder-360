using HouseFinder360.Domain.BuildingBlocks.DDD;

namespace HouseFinder360.RealEstates.Domain.RealEstates.Entities;

public class PropertyPhoto : Entity<long>
{
    public string Container { get; set; } = null!;
    public string Uri { get; set; } = null!;
    public string Name { get; set; } = null!;
}