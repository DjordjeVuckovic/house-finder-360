using FluentResults;
using HouseFinder360.Application.Authentication.Common;
using MediatR;

namespace HouseFinder360.Application.Authentication.Commands.Register;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password, 
    string Phone): IRequest<Result<AuthResult>>;