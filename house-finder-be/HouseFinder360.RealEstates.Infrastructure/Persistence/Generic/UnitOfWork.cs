using System.Data;
using FluentResults;
using HouseFinder360.RealEstates.Application.Common.Interfaces.Persistence.Generic;
using HouseFinder360.RealEstates.Domain.Common.Errors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace HouseFinder360.RealEstates.Infrastructure.Persistence.Generic;

public class UnitOfWork : IUnitOfWork
{
    private readonly HouseFinder360DbContext _context;

    public UnitOfWork(HouseFinder360DbContext context)
    {
        _context = context;
    }

    public IDbTransaction BeginTransaction()
    {
        var transaction = _context.Database.BeginTransaction();
        return transaction.GetDbTransaction();
    }

    public async Task<Result> Save(CancellationToken cancellationToken = default)
    {
        try
        {
            await _context.SaveChangesAsync(cancellationToken);
            return Result.Ok();
        }
        catch (DbUpdateException)
        {
            return Result.Fail(DomainErrors.Database.Conflict);
        }
    }
}
