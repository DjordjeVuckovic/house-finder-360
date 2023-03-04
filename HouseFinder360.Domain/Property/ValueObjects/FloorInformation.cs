using HouseFinder360.Domain.Common.BuildingBlocks;

namespace HouseFinder360.Domain.Property.ValueObjects;

public class FloorInformation:ValueObject
{
    public string Floor { get; private set; }
    public string TotalFloors { get; private set; }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Floor;
        yield return TotalFloors;
    }

    public FloorInformation(string floor, string totalFloors)
    {
        Floor = floor;
        TotalFloors = totalFloors;
    }

    private FloorInformation()
    {
    }
}