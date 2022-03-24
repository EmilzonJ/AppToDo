using System.Linq;
using Data.Persistence;
using Domain.Repositories;
using Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class RepositoryBase<T, TPKey> : IRepositoryBase<T, TPKey> where T : class, IEntityBase<TPKey>
{
    protected readonly AppDataContext _dbContext;

    public RepositoryBase(AppDataContext context)
    {
        _dbContext = context;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }

    public async Task<T?> GetByIdAsync(TPKey id)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }

    public async Task<T> AddAsync(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }
    
    public async Task AddRangeAsync(IEnumerable<T> entities)
    {
        await _dbContext.Set<T>().AddRangeAsync(entities);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _dbContext.Set<T>().Update(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateRangeAsync(params object[] entities)
    {
        _dbContext.UpdateRange(entities);
        await _dbContext.SaveChangesAsync();
    }

    public async Task RemoveAsync(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
        await _dbContext.SaveChangesAsync();
    }
        
    public async Task RemoveRangeAsync(IEnumerable<T> entities)
    {
       _dbContext.Set<T>().RemoveRange(entities);
       await _dbContext.SaveChangesAsync();

    }
}
