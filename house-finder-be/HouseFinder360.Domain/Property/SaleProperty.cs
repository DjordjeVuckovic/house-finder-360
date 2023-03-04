using HouseFinder360.Domain.Common.BuildingBlocks;
using HouseFinder360.Domain.Property.Entities;
using HouseFinder360.Domain.Property.Enums;
using HouseFinder360.Domain.Property.ValueObjects;

namespace HouseFinder360.Domain.Property;

public class SaleProperty : AggregateRoot<SalePropertyId>
{
    public string Title { get; private set; }
    public string Description { get; private set;}
    public int NumberOfRooms { get; private set; }
    public Address Address { get; private set; }
    public PropertyState PropertyState { get; private set; }
    public Area Area { get; private set; }
    public FloorInformation FloorInformation { get; private set;}
    public Price Price { get; private set;}
    public PropertyAdditionalInfo AdditionalInfo {get; private set;}
    public PropertyType PropertyType { get; private set;}
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