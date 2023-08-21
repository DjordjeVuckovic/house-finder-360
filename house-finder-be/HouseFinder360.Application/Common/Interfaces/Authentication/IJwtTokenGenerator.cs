using System;
using HouseFinder360.Domain.Users;

namespace HouseFinder360.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}