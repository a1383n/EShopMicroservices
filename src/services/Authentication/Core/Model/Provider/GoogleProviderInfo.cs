using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Core.Model.Provider;

[BsonDiscriminator("google")]
public class GoogleProviderInfo : ProviderInfo
{
    public override string Id => "google";

    public string AccountId { get; set; }

    public BsonTimestamp CreatedAt { get; set; } = new(DateTimeOffset.Now.ToUnixTimeSeconds());
    public BsonTimestamp LastUsedAt { get; set; } = new(DateTimeOffset.Now.ToUnixTimeSeconds());

    public GoogleProviderInfo(string accountId)
    {
        AccountId = accountId;
    }
}