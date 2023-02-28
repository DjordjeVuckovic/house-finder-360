using System;
using FluentResults;
using HouseFinder360.Application.Common.Errors;
using HouseFinder360.Application.Common.Interfaces.Authentication;
using HouseFinder360.Application.Common.Interfaces.Persistence;
using HouseFinder360.Domain.Entities;

namespace HouseFinder360.Application.Authentication;

public class AuthenticationService:IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public Result<AuthResult> Login(string email, string password)
    {
        var user = _userRepository.GetUserByEmail(email);
        if (user is null)
        {
            return Result.Fail<AuthResult>(new[] {ErrorResults.NotFound});
        }

        if (user.Password != password)
        {
            
        }
        return new AuthResult("token");
    }

    public Result<AuthResult> Register(string firstName, string lastName, string email, string password)
    {
        var user = _userRepository.GetUserByEmail(email);
        if (user is not null)
        {
            return Result.Fail<AuthResult>(new[] {ErrorResults.BadRequest});
        }
        var userId = Guid.NewGuid();
        var token = _jwtTokenGenerator.GenerateToken(userId, firstName, lastName,email);
        return Result.Ok(new AuthResult(token));
    }
}