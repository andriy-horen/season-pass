namespace SeasonPass.Core.Models;

public interface IEntity<T>
{
    T Id { get; }
}

public abstract class EntityBase : EntityBase<long> { }

public abstract class EntityBase<T> : IEntity<T>
{
    public required T Id { get; set; }
}
