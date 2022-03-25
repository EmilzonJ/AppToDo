using Domain.Filters;
using Task = Domain.Entities.Task;
using TaskStatus = Domain.Enums.TaskStatus;

namespace Domain.Repositories;

public interface ITaskRepository : IRepositoryBase<Task, Guid>
{
    Task<IEnumerable<Task>> GetAllByFilter(TaskFilter filter);
    /// <summary>
    /// Use to get one task by id using eager loading
    /// </summary>
    /// <param name="id">TaskId</param>
    /// <returns>Entitie Task</returns>
    Task<Task> GetTaskById(Guid id);
}