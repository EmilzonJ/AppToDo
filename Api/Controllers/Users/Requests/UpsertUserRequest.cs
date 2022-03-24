namespace Api.Controllers.Users.Requests;

public class UpsertUserRequest
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
}