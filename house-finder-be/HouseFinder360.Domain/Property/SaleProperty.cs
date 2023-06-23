using HouseFinder360.Domain.Common.BuildingBlocks;
using HouseFinder360.Domain.Property.Entities;
using HouseFinder360.Domain.Property.Enums;
using HouseFinder360.Domain.Property.ValueObjects;

namespace HouseFinder360.Domain.Property;

public class SaleProperty : AggregateRoot<SalePropertyId>
{
    public string Title { get; private set; } = null!;
    public string Description { get; private set;} = null!;
    public int NumberOfRooms { get; private set; }
    public Address Address { get; private set; } = null!;
    public PropertyState PropertyState { get; private set; }
    public Area Area { get; private set; } = null!;
    public FloorInformation FloorInformation { get; private set;} = null!;
    public Price Price { get; private set;} = null!;
    public PropertyAdditionalInfo AdditionalInfo {get; private set;} = null!;
    public PropertyType PropertyType { get; private set;} = null!;
    public RegisterStatus RegisterStatus { get; private set;}
    public SaleProperty(SalePropertyId id, string title, string description, Address address, Area area, 
        FloorInformation floorInformation, Price price, PropertyAdditionalInfo additionalInfo, 
        PropertyType propertyType) : base(id)
    {
        Title = title;
        Description = description;
        Address = address;
        Area = area;
        FloorInformation = floorInformation;
        Price = price;
        AdditionalInfo = additionalInfo;
        PropertyType = propertyType;
    }

    private SaleProperty()
    {
    }
}