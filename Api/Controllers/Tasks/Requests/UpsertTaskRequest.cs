using TaskStatus = Domain.Enums.TaskStatus;

namespace Api.Controllers.Tasks.Requests;

public class UpsertTaskRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public TaskStatus Status { get; set; }
    public Guid CategoryId { get; set; }
}