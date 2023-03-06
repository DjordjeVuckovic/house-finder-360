namespace HouseFinder360.Api.Requests.Property;

public record SalePropertyRequest(
    string Title,
    string Description,
    int NumberOfRooms, 
    AddressRequest AddressRequest,
    string PropertyState,
    int Area,
    string Floor,
    string TotalFloors,
    int Price,
    string PropertyType,
    string RegisterStatus
);