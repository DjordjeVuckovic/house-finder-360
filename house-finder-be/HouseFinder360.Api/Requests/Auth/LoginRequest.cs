namespace HouseFinder360.Api.Requests.Auth;

public record LoginRequest(
    string Email,
    string Password);