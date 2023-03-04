using HouseFinder360.Application.Common.Interfaces.Persistence.Generic;
using Microsoft.EntityFrameworkCore;

namespace HouseFinder360.Infrastructure.Persistence.Generic;

public class Repository<T,TId> : IRepository<T,TId>
where T : class
where TId : notnull
{
    protected readonly DbSet<T>  DbSet;

    protected Repository(DbContext dbContext)
    {
        DbSet = dbContext.Set<T>();
    }
    public async Task<T?> GetById(TId id)
    {
        return await DbSet.FindAsync(id);
    }

    public async Task Create(T entity)
    {
        await DbSet.AddAsync(entity);
    }

    public Task Update(T entity)
    {
        return Task.FromResult(DbSet.Update(entity));
    }

    public Task Delete(T entity)
    {
        return Task.FromResult(DbSet.Remove(entity));
    }

    public async Task<List<T>> GetAll()
    {
        return await DbSet.ToListAsync();
    }

    public async Task CreateBulk(IEnumerable<T> entities)
    {
       await DbSet.AddRangeAsync(entities);
    }
}