namespace HouseFinder360.Domain.Property.ValueObjects;

public class PropertyAdditionalInfo
{
    public DateOnly YearOfBuild { get; set; }
    public DateOnly AvailableFrom { get; set; }
    public int BalconyNumber { get; set; }
    public int BathroomNumber { get; set; }
    public int ToiletNumber { get; set; }
    public bool HaveKitchen { get; set; }
    public bool HaveStorage { get; set; }
    public bool HaveParking { get; set; }
}