using HouseFinder360.RealEstates.Application.Common.Interfaces.Persistence.Generic;
using Microsoft.EntityFrameworkCore;

namespace HouseFinder360.RealEstates.Infrastructure.Persistence.Generic;

public class Repository<T, TId> : IRepository<T, TId>
where T : class
where TId : notnull
{
    protected readonly DbSet<T> DbSet;

    protected Repository(HouseFinder360DbContext dbContext)
    {
        DbSet = dbContext.Set<T>();
    }
    public async Task<T?> GetById(TId id, CancellationToken cancellationToken = default)
    {
        return await DbSet.FindAsync(new object?[] { id, cancellationToken }, cancellationToken: cancellationToken);
    }

    public async Task Create(T entity)
    {
        await DbSet.AddAsync(entity);
    }

    public void Update(T entity)
    {
        DbSet.Update(entity);
    }

    public void Delete(T entity)
    {
        DbSet.Remove(entity);
    }

    public async Task<List<T>> GetAll(CancellationToken cancellationToken = default)
    {
        return await DbSet.ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task CreateBulk(IEnumerable<T> entities)
    {
        await DbSet.AddRangeAsync(entities);
    }
}
