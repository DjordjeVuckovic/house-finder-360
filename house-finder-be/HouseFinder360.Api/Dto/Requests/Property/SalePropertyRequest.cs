namespace HouseFinder360.Api.Dto.Requests.Property;

public record SalePropertyRequest(
    string Title,
    string Description,
    string RoomsNumber, 
    AddressRequest Address,
    string Condition,
    int Area,
    string Floor,
    string TotalFloors,
    int Price,
    string Type,
    string RegisterStatus,
    string Heating,
    int ElevatorsNumber,
    int NumberOfToilets, 
    int BathroomsNumber, 
    int NumberOfBalconies,
    Guid UserId);