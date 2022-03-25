using Data.Persistence;
using Domain.Filters;
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
    
    public async Task<IEnumerable<Task>> GetAllByFilter(TaskFilter filters)
    {
        if(filters.Status == null) filters.Status = new List<TaskStatus>{TaskStatus.New, TaskStatus.InProgress, TaskStatus.Completed};
        var tasks = _dbContext.Tasks.Where(_ => filters.Status.Contains(_.Status));
        
        if(filters.UserId != null) tasks = tasks.Where(_ => _.UserId == filters.UserId);
        if(!String.IsNullOrEmpty(filters.UserName)) tasks = tasks.Where(_ => _.User.UserName == filters.UserName);
        if(filters.CategoryId != null) tasks = tasks.Where(_ => _.CategoryId == filters.CategoryId);
        if(!String.IsNullOrEmpty(filters.CategoryName)) tasks = tasks.Where(_ => _.Category.Name == filters.CategoryName);
        
        return await tasks.ToListAsync();
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