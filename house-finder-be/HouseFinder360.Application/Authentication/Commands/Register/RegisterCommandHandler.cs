using FluentResults;
using HouseFinder360.Application.Authentication.Common;
using HouseFinder360.Application.Common.Errors;
using HouseFinder360.Application.Common.Interfaces.Authentication;
using HouseFinder360.Application.Common.Interfaces.Persistence.Generic;
using HouseFinder360.Application.Users.Queries;
using HouseFinder360.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace HouseFinder360.Application.Authentication.Commands.Register;

public class RegisterCommandHandler: IRequestHandler<RegisterCommand, Result<AuthResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly ISender _sender;
    private readonly IPasswordHasher<User> _hasher;
    private readonly IDbContext _context;

    public RegisterCommandHandler(
        IJwtTokenGenerator jwtTokenGenerator,
        IDbContext context, 
        ISender sender, 
        IPasswordHasher<User> hasher)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _context = context;
        _sender = sender;
        _hasher = hasher;
    }

    public async Task<Result<AuthResult>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var userByEmailResult = await _sender.Send(new GetByEmailQuery(request.Email), cancellationToken);
        var userByPhone = await _sender.Send(new GetByEmailQuery(request.Phone), cancellationToken);
        if (userByEmailResult.IsSuccess || userByPhone.IsSuccess)
        {
            var error = Result.Fail<AuthResult>(ApplicationErrors.Users.WrongCredential);
            return error;
        }
        var user = new User(
            Guid.NewGuid(), 
            request.FirstName, 
            request.LastName, 
            request.Email, 
            request.Password,
            UserRole.User,
            request.Phone);
        var hashed = _hasher.HashPassword(user,request.Password);
        user.SetHash(hashed);
        await _context.Users.AddAsync(user,cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthResult(token);
    }
}