namespace HouseFinder360.Api.Dto.Requests.Auth;

public record LoginRequest(
    string EmailOrPhone,
    string Password);