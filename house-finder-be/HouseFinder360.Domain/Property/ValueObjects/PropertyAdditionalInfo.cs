using HouseFinder360.Domain.Common.BuildingBlocks;

namespace HouseFinder360.Domain.Property.ValueObjects;

public class PropertyAdditionalInfo: Entity<long>
{
    public DateOnly YearOfBuild { get; set; }
    public DateOnly AvailableFrom { get; set; }
    public int BalconyNumber { get; private set; }
    public int BathroomNumber { get; private set; }
    public int ToiletNumber { get; private set; }
    public bool HaveKitchen { get; private set; }
    public bool HaveStorage { get; private set; }
    public bool HaveParking { get; private set; }
    public SalePropertyId PropertyId { get; private set; }

    public PropertyAdditionalInfo(DateOnly yearOfBuild, DateOnly availableFrom, int balconyNumber, int bathroomNumber, int toiletNumber, bool haveKitchen, bool haveStorage, bool haveParking)
    {
        YearOfBuild = yearOfBuild;
        AvailableFrom = availableFrom;
        BalconyNumber = balconyNumber;
        BathroomNumber = bathroomNumber;
        ToiletNumber = toiletNumber;
        HaveKitchen = haveKitchen;
        HaveStorage = haveStorage;
        HaveParking = haveParking;
    }

    private PropertyAdditionalInfo()
    {
    }
}