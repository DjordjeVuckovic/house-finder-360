namespace HouseFinder360.Api.Dto.Requests.Property;

public record AddressRequest(
    string Street,
    string City,
    double CityLongitude,
    double CityLatitude,
    string Country,
    double StreetLongitude,
    double StreetLatitude
    );