using FluentResults;
using HouseFinder360.Application.Common.Interfaces.Persistence.Generic;
using HouseFinder360.Domain.Common.Errors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace HouseFinder360.Infrastructure.Persistence.Generic;

public class UnitOfWork : IUnitOfWork
{
    private readonly HouseFinder360DbContext _context;
    private IDbContextTransaction? _transaction;

    public UnitOfWork(HouseFinder360DbContext context, IDbContextTransaction? transaction)
    {
        _context = context;
        _transaction = transaction;
    }

    public Task BeginTransaction()
    {
        _transaction ??= _context.Database.BeginTransaction();
        return Task.CompletedTask;
    }

    public async Task<Result> Save()
    {
        try
        {
            await _context.SaveChangesAsync();
            return Result.Ok();
        }
        catch (DbUpdateException)
        {
            return Result.Fail(DomainErrors.Database.Conflict);
        }
    }

    public async Task<Result> Commit()
    {
        if (_transaction is null) return Result.Fail(DomainErrors.Database.TransactionConflict);
        await _transaction.CommitAsync();
        await _transaction.DisposeAsync();
        _transaction = null;
        return Result.Ok();
    }

    public async Task<Result> Rollback()
    {
        if (_transaction is null) return Result.Fail(DomainErrors.Database.TransactionConflict);
        await _transaction.RollbackAsync();
        await _transaction.DisposeAsync();
        _transaction = null;
        return Result.Ok();
    }
}