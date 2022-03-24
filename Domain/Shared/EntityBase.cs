namespace Domain.Shared;

public abstract class EntityBase<TPKey> : IEntityBase<TPKey>
{
    public DateTime CreatedOn { get; set; }
    public DateTime? UpdatedOn { get; set; }
    public TPKey Id { get; set; }
}

public interface IEntityBase<out TPKey> : IEntityBase
{
    TPKey Id { get; }
}

public interface IEntityBase
{
    DateTime CreatedOn { get; set; }
    DateTime? UpdatedOn { get; set; }
}