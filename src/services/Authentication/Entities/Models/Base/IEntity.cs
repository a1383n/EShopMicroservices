using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Entities.Models.Base;

public interface IEntity
{
    //
}

public interface IEntity<TKey> : IEntity
{
    [JsonPropertyOrder(-10)]
    TKey Id { get; set; }
}

public abstract class BaseEntity<TKey> : IEntity<TKey> where TKey : IEquatable<TKey>
{
    public TKey Id { get; set; }
}

public abstract class BaseEntity : IEntity<ObjectId>
{
    [BsonId]
    public ObjectId Id { get; set; }
}