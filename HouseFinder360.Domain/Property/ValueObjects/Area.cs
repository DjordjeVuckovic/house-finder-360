using HouseFinder360.Domain.Common.BuildingBlocks;

namespace HouseFinder360.Domain.Property.ValueObjects;

public class Area : ValueObject
{
    public int SquadMeter { get; set; }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return SquadMeter;
    }

    public Area(int squadMeter)
    {
        SquadMeter = squadMeter;
    }

    private Area()
    {
    }
}