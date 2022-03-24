using Task = Domain.Entities.Task;

namespace Domain.Repositories;

public interface ITaskRepository : IRepositoryBase<Task, Guid>
{
    Task<IEnumerable<Task>> GetAllByUser(Guid userId);
}