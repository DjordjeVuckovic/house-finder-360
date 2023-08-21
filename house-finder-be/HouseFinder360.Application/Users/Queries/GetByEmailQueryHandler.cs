using FluentResults;
using HouseFinder360.Application.Common.Errors;
using HouseFinder360.Application.Common.Interfaces.Persistence.Generic;
using HouseFinder360.Domain.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HouseFinder360.Application.Users.Queries;

public class GetByEmailQueryHandler : IRequestHandler<GetByEmailQuery,Result<User>>
{
    private readonly IDbContext _dbContext;

    public GetByEmailQueryHandler(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Result<User>> Handle(GetByEmailQuery request, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users
            .SingleOrDefaultAsync(user => user.Email == request.Email,cancellationToken);
        if (user is null)
        {
            return Result.Fail(ApplicationErrors.Users.WrongCredential);
        }

        return user;
    }
}
public record GetByEmailQuery(string Email) : IRequest<Result<User>>;