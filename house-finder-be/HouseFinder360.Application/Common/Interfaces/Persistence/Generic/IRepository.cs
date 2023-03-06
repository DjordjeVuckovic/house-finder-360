namespace HouseFinder360.Application.Common.Interfaces.Persistence.Generic;

public interface IRepository<T, in TId> 
    where T : class
    where TId : notnull 
{
    Task<T?> GetById(TId id, CancellationToken cancellationToken = default);
    Task Create(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task<List<T>> GetAll(CancellationToken cancellationToken = default);
    Task CreateBulk(IEnumerable<T> entities);
}