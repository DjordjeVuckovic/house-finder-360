namespace HouseFinder360.Users.Api.Dto.Requests;

public record LoginRequest(
    string EmailOrPhone,
    string Password);