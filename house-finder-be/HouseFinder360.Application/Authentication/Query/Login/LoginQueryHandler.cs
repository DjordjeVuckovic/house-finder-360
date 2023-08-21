using FluentResults;
using HouseFinder360.Application.Authentication.Common;
using HouseFinder360.Application.Common.Errors;
using HouseFinder360.Application.Common.Interfaces.Authentication;
using HouseFinder360.Application.Common.Interfaces.Persistence;
using HouseFinder360.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace HouseFinder360.Application.Authentication.Query.Login;

public class LoginQueryHandler: IRequestHandler<LoginQuery, Result<AuthResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher<User> _hasher;

    public LoginQueryHandler(
        IJwtTokenGenerator jwtTokenGenerator, 
        IUserRepository userRepository, 
        IPasswordHasher<User> hasher)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
        _hasher = hasher;
    }

    public async Task<Result<AuthResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByEmail(query.EmailOrPhone);
        if (user is null)
        {
            return Result.Fail<AuthResult>(ApplicationErrors.Users.WrongCredential);
        }

        var result = _hasher.VerifyHashedPassword(user, user.Password, query.Password);

        if (result == PasswordVerificationResult.Failed)
        {
            return Result.Fail<AuthResult>(ApplicationErrors.Users.WrongCredential);
        }
        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthResult(token);
    }
}