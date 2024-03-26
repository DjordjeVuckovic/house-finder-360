using FluentResults;
using HouseFinder360.Users.Infrastructure.Features.Authentication.Common;
using MediatR;

namespace HouseFinder360.Users.Infrastructure.Features.Authentication.Commands.Register;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password,
    string Phone,
    string Role) : IRequest<Result<AuthResult>>;
