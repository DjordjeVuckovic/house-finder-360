using HouseFinder360.Domain.BuildingBlocks.DDD;

namespace HouseFinder360.RealEstates.Domain.RealEstates.ValueObjects;

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