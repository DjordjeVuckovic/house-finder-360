using FluentResults;
using HouseFinder360.Users.Infrastructure.Common.Errors;
using HouseFinder360.Users.Infrastructure.Model;
using HouseFinder360.Users.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HouseFinder360.Users.Infrastructure.Features.Users.Queries;

public class GetByPhoneQueryHandler : IRequestHandler<GetByPhoneQuery,Result<User>>
{
    private readonly UserDbContext _dbContext;

    public GetByPhoneQueryHandler(UserDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Result<User>> Handle(GetByPhoneQuery request, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users
            .SingleOrDefaultAsync(x => x.PhoneNumber == request.Phone, cancellationToken);
        if (user is null)
        {
            return Result.Fail(UsersErrors.WrongCredential);
        }
        return user;
    }
}
public record GetByPhoneQuery(string Phone) : IRequest<Result<User>>;