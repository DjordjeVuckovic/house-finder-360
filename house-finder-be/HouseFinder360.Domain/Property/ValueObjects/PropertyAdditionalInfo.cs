using HouseFinder360.BuildingBlocks.BuildingBlocks;

namespace HouseFinder360.Domain.Property.ValueObjects;

public class PropertyAdditionalInfo : ValueObject
{
    public DateOnly YearOfBuild { get; init; }
    public DateOnly AvailableFrom { get; init; }
    public int BalconyNumber { get;  init; }
    public int BathroomNumber { get; init; }
    public int ToiletNumber { get;  init; }
    public bool HaveKitchen { get; init; }
    public bool HaveStorage { get; init; }
    public bool HaveParking { get; init; }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return YearOfBuild;
        yield return AvailableFrom;
        yield return BalconyNumber;
        yield return BathroomNumber;
        yield return ToiletNumber;
        yield return HaveKitchen;
        yield return HaveStorage;
        yield return HaveParking;
    }
}