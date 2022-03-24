namespace Api.Controllers.Tasks.Responses;

public class TaskUserResponse
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
}