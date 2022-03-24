namespace Api.Controllers.Tasks.Responses;

public class TaskResponse : AllTaskResponse
{
    public virtual TaskCategoryResponse Category { get; set; }
    public virtual TaskUserResponse User { get; set; }
}