using MongoDB.Bson.Serialization.Attributes;

namespace Entities.Models;

public class UserProfile
{
    [BsonIgnoreIfNull]
    public string? DisplayName { get; set; }

    [BsonIgnoreIfNull]
    public string? AvatarUrl { get; set; }
}
