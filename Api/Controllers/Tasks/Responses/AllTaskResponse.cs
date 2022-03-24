using TaskStatus = Domain.Enums.TaskStatus;

namespace Api.Controllers.Tasks.Responses;

public class AllTaskResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public TaskStatus Status { get; set; }
}