namespace HouseFinder360.Api.Dto.Requests.Auth;

public record LoginRequest(
    string Email,
    string Password);