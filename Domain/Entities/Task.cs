using Domain.Shared;
using TaskStatus = Domain.Enums.TaskStatus;

namespace Domain.Entities;

public class Task : EntityBase<Guid>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public TaskStatus Status { get; set; }
    public Guid CategoryId { get; set; }
    public virtual Category Category { get; set; }
}