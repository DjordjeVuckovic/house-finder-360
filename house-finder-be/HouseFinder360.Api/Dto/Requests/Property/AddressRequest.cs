namespace HouseFinder360.Api.Dto.Requests.Property;

public record AddressRequest(
    string Street,
    string StreetNumber,
    string City,
    string Country
    );