using MongoDB.Bson;

namespace Entities.Models.Base;

public interface IAuditableEntity : IEntity
{
    DateTime CreatedAt { get; set; }
    DateTime? UpdatedAt { get; set; }
}

public abstract class AuditableEntity<TKey> : BaseEntity<TKey>, IAuditableEntity where TKey : IEquatable<TKey>
{
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}

public abstract class AuditableBaseEntity : AuditableEntity<ObjectId>
{
    //
}