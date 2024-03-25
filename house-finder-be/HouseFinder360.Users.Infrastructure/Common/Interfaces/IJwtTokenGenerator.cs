using HouseFinder360.Users.Infrastructure.Model;

namespace HouseFinder360.Users.Infrastructure.Common.Interfaces;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}
