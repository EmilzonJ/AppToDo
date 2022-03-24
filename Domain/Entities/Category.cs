using Domain.Shared;

namespace Domain.Entities;

public class Category : EntityBase<Guid>
{
    public string Name { get; set; }
}