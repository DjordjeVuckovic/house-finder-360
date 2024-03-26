using FluentResults;
using HouseFinder360.Users.Infrastructure.Common.Errors;
using HouseFinder360.Users.Infrastructure.Common.Interfaces;
using HouseFinder360.Users.Infrastructure.Features.Authentication.Common;
using HouseFinder360.Users.Infrastructure.Model;
using HouseFinder360.Users.Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HouseFinder360.Users.Infrastructure.Features.Authentication.Query.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, Result<AuthResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly UserDbContext _dbContext;
    private readonly UserManager<User> _userManager;

    public LoginQueryHandler(
        IJwtTokenGenerator jwtTokenGenerator,
        UserDbContext dbContext,
        UserManager<User> userManager)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _dbContext = dbContext;
        _userManager = userManager;
    }

    public async Task<Result<AuthResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users
            .Include(x => x.Roles)
            .SingleOrDefaultAsync(x =>
            x.PhoneNumber == query.EmailOrPhone || x.Email == query.EmailOrPhone,
            cancellationToken);

        if (user is null)
        {
            return Result.Fail<AuthResult>(UsersErrors.WrongCredentialForUser(query.EmailOrPhone));
        }

        var passwordValid = await _userManager.CheckPasswordAsync(user, query.Password);
        if (!passwordValid)
        {
            return Result.Fail<AuthResult>(UsersErrors.WrongCredentialForUser(query.EmailOrPhone));
        }

        try
        {
            var token = _jwtTokenGenerator.GenerateToken(user);
            return new AuthResult(token);
        }
        catch (Exception exception)
        {
            return Result.Fail<AuthResult>(UsersErrors.CannotGenerateToken);
        }
    }
}
