using MongoDB.Bson.Serialization.Attributes;

namespace Core.Model.Provider;

[BsonKnownTypes(typeof(EmailProviderInfo), typeof(PhoneProviderInfo), typeof(GoogleProviderInfo))]
public abstract class ProviderInfo
{
    [BsonId]
    public abstract string Id { get; }
}
