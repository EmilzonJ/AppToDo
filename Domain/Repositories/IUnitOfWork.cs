namespace Domain.Repositories;

public interface IUnitOfWork : IDisposable
{
    ITaskRepository Tasks { get; }
}