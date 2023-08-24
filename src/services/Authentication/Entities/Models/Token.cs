using Entities.Models.Base;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Entities.Models;

public class Token : IEntity
{
    [BsonId]
    public ObjectId Id;
    
    public ObjectId UserId;

    public Device Device;
    
    public BsonTimestamp ExpireAt;
}