using TaskStatus = Domain.Enums.TaskStatus;

namespace Api.Controllers.Tasks.Requests;

public class TaskQueryFilter
{
    public Guid UserId { get; set; }
    public Guid CategoryId { get; set; }
    public TaskStatus Status { get; set; }
}