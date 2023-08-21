using FluentResults;
using HouseFinder360.Application.Common.Errors;
using HouseFinder360.Application.Common.Interfaces.Persistence.Generic;
using HouseFinder360.Domain.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HouseFinder360.Application.Users.Queries;

public class GetByPhoneQueryHandler : IRequestHandler<GetByPhoneQuery,Result<User>>
{
    private readonly IDbContext _dbContext;

    public GetByPhoneQueryHandler(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Result<User>> Handle(GetByPhoneQuery request, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users
            .SingleOrDefaultAsync(x => x.Phone == request.Phone, cancellationToken);
        if (user is null)
        {
            return Result.Fail(ApplicationErrors.Users.WrongCredential);
        }
        return user;
    }
}
public record GetByPhoneQuery(string Phone) : IRequest<Result<User>>;