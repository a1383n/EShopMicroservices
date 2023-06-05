using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Core.Model.Provider;

[BsonDiscriminator("phone")]
public class PhoneProviderInfo : ProviderInfo
{
    public override string Id => "phone";

    public BsonTimestamp VerifiedAt { get; set; } = new(DateTimeOffset.Now.ToUnixTimeSeconds());
}