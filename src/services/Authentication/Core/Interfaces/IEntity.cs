namespace Core.Interfaces;

public interface IEntity
{
    //
}

public interface IEntity<TKey> : IEntity
{
    TKey Id { get; set; }
}

public abstract class BaseEntity<TKey> : IEntity<TKey> where TKey : IEquatable<TKey>
{
    public TKey Id { get; set; }
}