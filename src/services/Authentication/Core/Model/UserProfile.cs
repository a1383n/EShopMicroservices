using MongoDB.Bson.Serialization.Attributes;

namespace Core.Model;

public class UserProfile
{
    [BsonIgnoreIfNull]
    public string? DisplayName { get; set; }

    [BsonIgnoreIfNull]
    public string? AvatarUrl { get; set; }
}
