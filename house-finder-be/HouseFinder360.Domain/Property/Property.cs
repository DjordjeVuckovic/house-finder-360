using FluentResults;
using HouseFinder360.BuildingBlocks.BuildingBlocks;
using HouseFinder360.Domain.Common.Utils;
using HouseFinder360.Domain.Property.Entities;
using HouseFinder360.Domain.Property.Enums;
using HouseFinder360.Domain.Property.ValueObjects;

namespace HouseFinder360.Domain.Property;

public sealed class Property : AggregateRoot<Guid>
{
    public string Title { get; private set; } = null!;
    public string Description { get; private set;} = null!;
    public string NumberOfRooms { get; private set; } = null!;
    public Address Address { get; private set; } = null!;
    public string? PropertyState { get; private set; }
    public Area Area { get; private set; } = null!;
    public FloorInformation FloorInformation { get; private set;} = null!;
    public Price Price { get; private set;} = null!;
    public PropertyAdditionalInfo AdditionalInfo {get; private set;} = null!;
    public PropertyType PropertyType { get; private set;} = null!;
    public RegisterStatus RegisterStatus { get; private set;}
    public string? Heating { get;private set; }
    public PropertyPurpose Purpose { get;private set; }
    
    public int ElevatorsNumber { get; set; }
    public List<PropertyPhoto> Photos { get; private set; } = new();

    private Property(
        string title, 
        string description, 
        string numberOfRooms, 
        Address address,
        string? propertyState,
        Area area,
        FloorInformation floorInformation,
        Price price, 
        PropertyAdditionalInfo additionalInfo,
        PropertyType propertyType,
        RegisterStatus registerStatus,
        string? heating,
        int elevatorsNumber,
        PropertyPurpose purpose)
    {
        Title = title;
        Description = description;
        NumberOfRooms = numberOfRooms;
        Address = address;
        PropertyState = propertyState;
        Area = area;
        FloorInformation = floorInformation;
        Price = price;
        AdditionalInfo = additionalInfo;
        PropertyType = propertyType;
        RegisterStatus = registerStatus;
        Heating = heating;
        ElevatorsNumber = elevatorsNumber;
        Id = new Guid();
    }
    private Property(
        string title, 
        string description, 
        string numberOfRooms, 
        Address address,
        string? propertyState,
        Area area,
        FloorInformation floorInformation,
        Price price, 
        PropertyAdditionalInfo additionalInfo,
        PropertyType propertyType,
        RegisterStatus registerStatus,
        string? heating,
        int elevatorsNumber,
        List<PropertyPhoto> photos,
        PropertyPurpose purpose)
    {
        Title = title;
        Description = description;
        NumberOfRooms = numberOfRooms;
        Address = address;
        PropertyState = propertyState;
        Area = area;
        FloorInformation = floorInformation;
        Price = price;
        AdditionalInfo = additionalInfo;
        PropertyType = propertyType;
        RegisterStatus = registerStatus;
        Heating = heating;
        ElevatorsNumber = elevatorsNumber;
        Id = new Guid();
        Purpose = purpose;
        Photos = photos;
    }

    public static Result<Property> CreateSaleProperty(
        string title, 
        string description,
        int area,
        string roomsNumber, 
        Address address,
        string condition,
        string floor,
        string totalFloors,
        int price,
        string type,
        string registerStatus,
        string heating,
        int elevatorsNumber,
        int balconiesNumber,
        int bathroomsNumber,
        int toiletsNumber,
        DateTime yearOfBuild,
        List<PropertyPhoto> photos
        )
    {
        var areaResult = Area.CreateArea(area);
        var priceResult = Price.CreatePrice(price, "euro");
        var status = EnumUtil.ToEnum<RegisterStatus>(registerStatus);
        var merged = Result.Merge(priceResult, areaResult,status);
        if (merged.IsFailed)
        {
            return merged;
        }
        var additionalInfo = new PropertyAdditionalInfo
        {
            YearOfBuild = DateOnly.FromDateTime(yearOfBuild),
            AvailableFrom = DateOnly.FromDateTime(DateTime.Now),
            BalconyNumber = balconiesNumber,
            BathroomNumber = bathroomsNumber,
            ToiletNumber = toiletsNumber,
            HaveKitchen = true,
            HaveStorage = false,
            HaveParking = false
        };
        var propertyType = PropertyType.CreatePropertyType(
            PropertyType.TypeOfPropertyToEnum(type),
            string.Empty);
        var floorInformation = new FloorInformation(floor, totalFloors);
        return new Property(
            title,
            description,
            roomsNumber,
            address,
            condition,
            areaResult.Value,
            floorInformation,
            priceResult.Value,
            additionalInfo,
            propertyType.Value,
            status.Value,
            heating,
            elevatorsNumber,
            photos, 
            PropertyPurpose.Sale);
    }

    private Property()
    {
    }
}