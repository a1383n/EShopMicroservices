using Entities.Models.Providers.Info;
using MongoDB.Bson.Serialization.Attributes;

namespace Entities.Models.Providers.Base;

[BsonKnownTypes(typeof(EmailProviderInfo), typeof(PhoneProviderInfo), typeof(GoogleProviderInfo))]
public abstract class ProviderInfo
{
    [BsonId]
    public abstract string Id { get; }
}
