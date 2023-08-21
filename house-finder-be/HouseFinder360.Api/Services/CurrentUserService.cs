using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using HouseFinder360.Application.Common.Interfaces.Authentication;

namespace HouseFinder360.Api.Services;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _contextAccessor;

    public CurrentUserService(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }

    public string? UserEmail => _contextAccessor.HttpContext?.User.FindFirstValue(JwtRegisteredClaimNames.Email);
}