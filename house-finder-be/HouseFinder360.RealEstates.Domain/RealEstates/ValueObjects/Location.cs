using HouseFinder360.Domain.BuildingBlocks.DDD;

namespace HouseFinder360.RealEstates.Domain.RealEstates.ValueObjects;

public class Location : ValueObject
{
    public string Name { get; init; } = null!;
    public double Longitude { get; init; }
    public double Latitude { get; init; }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
        yield return Longitude;
        yield return Latitude;
    }
}
