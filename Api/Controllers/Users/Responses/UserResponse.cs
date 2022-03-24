namespace Api.Controllers.Users.Responses;

public class UserResponse
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
}