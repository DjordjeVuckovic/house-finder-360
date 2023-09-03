using FluentResults;
using HouseFinder360.Users.Infrastructure.Model;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace HouseFinder360.Users.Infrastructure.Features.Users.Commands;

public class CreateRoleHandler : IRequestHandler<CreateRoleCommand,Result>
{
    private readonly RoleManager<UserRole> _roleManager;

    public CreateRoleHandler(RoleManager<UserRole> roleManager)
    {
        _roleManager = roleManager;
    }

    public async Task<Result> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        if (await _roleManager.RoleExistsAsync(request.Name.ToUpper())) return Result.Ok();
        var role = new UserRole
        {
            Name = request.Name
        };
        await _roleManager.CreateAsync(role);

        return Result.Ok();
    }
}
public record CreateRoleCommand(string Name) : IRequest<Result>;