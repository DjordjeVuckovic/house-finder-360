using HouseFinder360.Domain.Common.BuildingBlocks;

namespace HouseFinder360.Domain.Property.ValueObjects;

public class FloorInformation:ValueObject
{
    public string Floor { get; set; }
    public string TotalFloors { get; set; }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Floor;
        yield return TotalFloors;
    }
}