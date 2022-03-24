using Data.Persistence;
using Domain.Repositories;

namespace Data.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDataContext _context;

    public UnitOfWork(AppDataContext context)
    {
        _context = context;
        Tasks = new TaskRepository(context);
    }

    public ITaskRepository Tasks { get; }
    
    public void Dispose()
    {
        _context.Dispose();
    }
}