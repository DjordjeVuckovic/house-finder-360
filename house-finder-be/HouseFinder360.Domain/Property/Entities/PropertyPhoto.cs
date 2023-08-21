using HouseFinder360.BuildingBlocks.BuildingBlocks;

namespace HouseFinder360.Domain.Property.Entities;

public class PropertyPhoto : Entity<long>
{
    public string Container { get; set; } = null!;
    public string Uri { get; set; } = null!;
    public string Name { get; set; } = null!;
}