using FluentResults;

namespace HouseFinder360.Application.Authentication;

public interface IAuthenticationService
{
   Result<AuthResult> Login(string email, string password);
   Result<AuthResult> Register(string firstName, string lastName, string email, string password);
}