namespace HouseFinder360.Application.Common.Interfaces.Persistence.Generic;

public interface IRepository<T, in TId> 
    where T : class
    where TId : notnull 
{
    Task<T?> GetById(TId id);
    Task Create(T entity);
    Task Update(T entity);
    Task Delete(T entity);
    Task<List<T>> GetAll();
    Task CreateBulk(IEnumerable<T> entities);
}