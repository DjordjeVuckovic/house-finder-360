using HouseFinder360.Application.Common.Interfaces.Authentication;

namespace HouseFinder360.Application.Authentication;

public class AuthenticationService:IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public AuthResult Login(string email, string password)
    {
        return new AuthResult("token");
    }

    public AuthResult Register(string firstName, string lastName, string email, string password)
    {
        var userId = Guid.NewGuid();
        var token = _jwtTokenGenerator.GenerateToken(userId, firstName, lastName,email);
        return new AuthResult(token);
    }
}