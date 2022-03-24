using Data.Persistence;
using Domain.Repositories;
using Task = Domain.Entities.Task;

namespace Data.Repositories;

public class TaskRepository : RepositoryBase<Task, Guid>, ITaskRepository
{
    public TaskRepository(AppDataContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Task>> GetAllByUser(Guid userId)
    {
        throw new NotImplementedException();
    }
}