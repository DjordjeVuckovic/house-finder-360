namespace HouseFinder360.RealEstates.Application.Common.Dtos.Shared;

public record AddressDto(
    string Street,
    string City,
    string Country,
    double StreetLongitude,
    double StreetLatitude,
    double CityLongitude,
    double CityLatitude
    );