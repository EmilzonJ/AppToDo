using Domain.Shared;

namespace Domain.Entities;

public class User : EntityBase<Guid>
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public virtual ICollection<Task> Tasks { get; set; }
}