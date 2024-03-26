using HouseFinder360.RealEstates.Domain.RealEstates;
using HouseFinder360.RealEstates.Application.Common.Dtos.Shared;
using HouseFinder360.RealEstates.Application.RealEstates.Dto;

namespace HouseFinder360.RealEstates.Application.RealEstates.Mapper;

public static class PropertyMapper
{
    public static PropertyResponse MapProperty(RealEstate realEstate) => new()
    {
        Id = realEstate.Id,
        Title = realEstate.Title,
        Price = realEstate.Price.Value,
        Address = new AddressDto(
            realEstate.Address.Street.Name,
            realEstate.Address.City.Name,
            realEstate.Address.Country,
            realEstate.Address.Street.Longitude,
            realEstate.Address.Street.Latitude,
            realEstate.Address.Street.Longitude,
            realEstate.Address.City.Latitude),
        BedroomsNumber = realEstate.NumberOfRooms,
        BathroomsNumber = realEstate.AdditionalInfo.BathroomNumber,
        Area = realEstate.Area.SquadMeter,
        PropertyType = realEstate.PropertyType.TypeOfPropertyToString(),
        Purpose = realEstate.Purpose.ToString(),
        PropertyImageUris = realEstate.Photos.Select(p => p.Uri),
        Description = realEstate.Description
    };
}
