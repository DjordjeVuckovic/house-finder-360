namespace HouseFinder360.Api.Dto.Requests.Auth;

public record RegisterRequest(
    string FirstName,
    string LastName,
    string Email,
    string Password);