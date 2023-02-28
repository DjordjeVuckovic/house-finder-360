namespace HouseFinder360.Application.Authentication;

public interface IAuthenticationService
{
   AuthResult Login(string email, string password);
   AuthResult Register(string firstName, string lastName, string email, string password);
}