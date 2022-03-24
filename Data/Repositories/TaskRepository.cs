using Data.Persistence;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Task = Domain.Entities.Task;
using TaskStatus = Domain.Enums.TaskStatus;

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
    
    public async Task<IEnumerable<Task>> GetAllByCategory(Guid categoryId)
    {
        var tasks = await _dbContext.Tasks.Where(t => t.CategoryId == categoryId).ToListAsync();
        return tasks;
    }

    public async Task<IEnumerable<Task>> GetAllByStatus(TaskStatus status)
    {
        var tasks = await _dbContext.Tasks.Where(t => t.Status.Equals(status)).ToListAsync();
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