using Entities.Models.Base;
using Entities.Models.Providers.Base;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Entities.Models;

public class User: BaseEntity
{
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