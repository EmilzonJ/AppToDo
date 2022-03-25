using TaskStatus = Domain.Enums.TaskStatus;

namespace Domain.Filters;

public class TaskFilter
{
    public Guid? UserId { get; set; }
    public string? UserName { get; set; }
    public Guid? CategoryId { get; set; }
    public string? CategoryName { get; set; }
    public List<TaskStatus>? Status { get; set; }
}