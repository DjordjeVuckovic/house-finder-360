using FluentResults;
using HouseFinder360.Application.Authentication.Common;
using MediatR;

namespace HouseFinder360.Application.Authentication.Query.Login;

public record LoginQuery(
    string Email,
    string Password):IRequest<Result<AuthResult>>;