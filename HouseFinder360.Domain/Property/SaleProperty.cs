using HouseFinder360.Domain.Common.BuildingBlocks;
using HouseFinder360.Domain.Property.Entities;
using HouseFinder360.Domain.Property.Enums;
using HouseFinder360.Domain.Property.ValueObjects;

namespace HouseFinder360.Domain.Property;

public class SaleProperty : AggregateRoot<PropertyId>
{
    public string Title { get; }
    public string Description { get; }
    public int NumberOfRooms { get; set; }
    public Address Address { get; set; }
    public PropertyState PropertyState { get; set; }
    public Area Area { get; set; }
    public FloorInformation FloorInformation { get; set; }
    public Price Price { get; set; }
    public PropertyAdditionalInfo AdditionalInfo {get; set; }
    public PropertyType PropertyType { get; set; }
    public RegisterStatus RegisterStatus { get; set; }
    public SaleProperty(PropertyId id, string title, string description, Address address, Area area, 
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
}