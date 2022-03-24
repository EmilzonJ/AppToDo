using Data.Persistence;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Task = Domain.Entities.Task;

namespace Data.Repositories;

public class TaskRepository : RepositoryBase<Task, Guid>, ITaskRepository
{
    public TaskRepository(AppDataContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Task>> GetAllByUser(Guid userId)
    {
        var tasks = await _dbContext.Tasks.Where(t => t.UserId == userId).ToListAsync();
        return tasks;
    }


    public async Task<Task> GetTaskById(Guid id)
    {
        var task = await _dbContext.Tasks.Where(t => t.Id == id)
            .Include(_ => _.Category)
            .Include(_ => _.User)
            .FirstOrDefaultAsync();
        
        return task;
    }
}