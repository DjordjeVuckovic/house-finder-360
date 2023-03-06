namespace HouseFinder360.Api.Requests.Property;

public record AddressRequest(
    string Street,
    string StreetNumber,
    string City,
    string Country
    );