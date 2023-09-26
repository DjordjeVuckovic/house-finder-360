using FluentResults;
using HouseFinder360.Domain.BuildingBlocks.Common.Enums;
using HouseFinder360.Domain.BuildingBlocks.DDD;
using HouseFinder360.RealEstates.Domain.RealEstates.Entities;
using HouseFinder360.RealEstates.Domain.RealEstates.Enums;
using HouseFinder360.RealEstates.Domain.RealEstates.ValueObjects;

namespace HouseFinder360.RealEstates.Domain.RealEstates;

public sealed class RealEstate : AggregateRoot<Guid>
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
    public Guid UserId { get; private set; }
    public List<PropertyAction> Actions { get; private set; } = new();
    public int TotalLikes => Actions.Count(a => a.ActionType == ActionType.Like);
    public int TotalClicks => Actions.Count(a => a.ActionType == ActionType.Click);

    private RealEstate(
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
    private RealEstate(
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
        PropertyPurpose purpose,
        Guid userId)
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
        UserId = userId;
    }

    public static Result<RealEstate> CreateSaleProperty(
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
        List<PropertyPhoto> photos,
        Guid userId,
        string purpose
        )
    {
        var areaResult = Area.CreateArea(area);
        var priceResult = Price.CreatePrice(price, "euro");
        var status = EnumUtil.ToEnum<RegisterStatus>(registerStatus);
        var propPurpose = EnumUtil.ToEnum<PropertyPurpose>(purpose);
        var merged = Result.Merge(priceResult, areaResult,status,propPurpose);
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
        return new RealEstate(
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
            propPurpose.Value,
            userId);
    }

    private RealEstate()
    {
    }
}