namespace HouseFinder360.Users.Api.Dto.Requests;

public record RegisterRequest(
    string FirstName,
    string LastName,
    string Email,
    string Password,
    string Phone,
    string Role);
