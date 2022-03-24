namespace Domain.Repositories;

public interface IRepositoryBase<T, in TPKey> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(TPKey id);
    Task<T> AddAsync(T entity);
    Task AddRangeAsync(IEnumerable<T> entities);
    Task UpdateAsync(T entity);
    Task UpdateRangeAsync(params object[] entities);
    Task RemoveAsync(T entity);
    Task RemoveRangeAsync(IEnumerable<T> entities);
}