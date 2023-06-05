using Core.Interfaces;
using Core.Model.Provider;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Core.Model;

public class User: IEntity
{
    [BsonId]
    public ObjectId Id { get; set; }

    public List<ProviderInfo> Providers { get; set; }

    [BsonIgnoreIfNull]
    public UserProfile? Profile { get; set; }

    [BsonIgnoreIfDefault]
    public bool IsDisabled = false;

    [BsonIgnoreIfNull]
    public DateTime? LastSignInAt { get; set; }

    [BsonIgnoreIfNull]
    public DateTime? LastRefreshAt { get; set; }

    [BsonIgnoreIfNull] 
    public DateTime? UpdatedAt { get; set; }

    public User(List<ProviderInfo> providers)
    {
        Providers = providers;
    }
}