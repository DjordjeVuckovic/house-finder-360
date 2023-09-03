using HouseFinder360.BuildingBlocks.BuildingBlocks;

namespace HouseFinder360.Domain.Properties.ValueObjects;

public class FloorInformation:ValueObject
{
    public string Floor { get; private set; } = null!;
    public string TotalFloors { get; private set; } = null!;

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