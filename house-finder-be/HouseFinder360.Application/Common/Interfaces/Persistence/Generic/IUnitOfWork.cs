using System.Data;
using FluentResults;

namespace HouseFinder360.Application.Common.Interfaces.Persistence.Generic;

public interface IUnitOfWork
{
    public IDbTransaction BeginTransaction();
    public Task<Result> Save(CancellationToken cancellationToken = default);

}