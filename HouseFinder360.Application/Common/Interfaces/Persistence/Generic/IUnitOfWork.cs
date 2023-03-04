using FluentResults;

namespace HouseFinder360.Application.Common.Interfaces.Persistence.Generic;

public interface IUnitOfWork
{
    public Task BeginTransaction();
    public Task<Result> Save();
    public Task<Result> Commit();
    public Task<Result> Rollback();
    
}