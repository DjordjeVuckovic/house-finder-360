using FluentResults;
using FluentValidation;
using HouseFinder360.Domain.BuildingBlocks.Errors;
using HouseFinder360.Users.Infrastructure.Common.Errors;
using HouseFinder360.Users.Infrastructure.Common.Interfaces;
using HouseFinder360.Users.Infrastructure.Features.Authentication.Common;
using HouseFinder360.Users.Infrastructure.Features.Users.Commands;
using HouseFinder360.Users.Infrastructure.Features.Users.Queries;
using HouseFinder360.Users.Infrastructure.Model;
using HouseFinder360.Users.Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace HouseFinder360.Users.Infrastructure.Features.Authentication.Commands.Register;

public class RegisterCommandHandler: IRequestHandler<RegisterCommand, Result<AuthResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly ISender _sender;
    private readonly UserManager<User> _userManager;
    private readonly UserDbContext _dbContext;
    public RegisterCommandHandler(
        IJwtTokenGenerator jwtTokenGenerator,
        ISender sender, 
        UserManager<User> userManager, 
        UserDbContext dbContext)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _sender = sender;
        _userManager = userManager;
        _dbContext = dbContext;
    }

    public async Task<Result<AuthResult>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        await using var transaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);

        var userByEmailResult = await _sender.Send(new GetByEmailQuery(request.Email), cancellationToken);
        var userByPhone = await _sender.Send(new GetByPhoneQuery(request.Phone), cancellationToken);
        
        if (userByEmailResult.IsSuccess || userByPhone.IsSuccess)
        {
            var error = Result.Fail<AuthResult>(UsersErrors.WrongCredential);
            return error;
        }

        var user = new User
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            PhoneNumber = request.Phone,
            Email = request.Email,
            UserName = request.Email
        };
        
        var result = await _userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
        {
            return  Result.Fail(result.Errors.Select(x => 
                new ErrorResult(x.Description, 
                ErrorStatusCodes.BadRequest)));
        }
        var roleResult = await _sender.Send(new CreateRoleCommand(request.Role), cancellationToken);
        var roleAssignResult = user.AssignRole(request.Role);
        if (roleAssignResult.IsFailed)
        {
            await transaction.RollbackAsync(cancellationToken);
            return Result.Fail(UsersErrors.RoleAssign);
        }
        if (roleResult.IsFailed)
        {
            await transaction.RollbackAsync(cancellationToken);
            return Result.Fail(UsersErrors.Role);
        }

        try
        {
            await _userManager.AddToRoleAsync(user, request.Role);
        }
        catch
        {
            return Result.Fail(UsersErrors.Role); 
        }

        await transaction.CommitAsync(cancellationToken);
        
        var token = _jwtTokenGenerator.GenerateToken(user);
        
        
        return new AuthResult(token);
    }
}