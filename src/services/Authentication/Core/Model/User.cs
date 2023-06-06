using Core.Interfaces;
using Core.Model.Provider;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Core.Model;

public class User: IEntity
{
    [BsonId]
    public ObjectId Id { get; set; }

    [BsonIgnoreIfNull]
    public string? Email;

    [BsonIgnoreIfNull]
    public string? Phone;

    [BsonIgnoreIfNull]
    public string? Password;
    
    public List<ProviderInfo> Providers { get; set; }

    [BsonIgnoreIfNull]
    public UserProfile? Profile { get; set; }

    [BsonIgnoreIfDefault]
    public bool IsDisabled = false;

    [BsonIgnoreIfNull]
    public BsonTimestamp? LastSignInAt { get; set; }

    [BsonIgnoreIfNull]
    public BsonTimestamp? LastRefreshAt { get; set; }

    [BsonIgnoreIfNull] 
    public BsonTimestamp? UpdatedAt { get; set; }

    public User(List<ProviderInfo> providers)
    {
        Providers = providers;
    }
}