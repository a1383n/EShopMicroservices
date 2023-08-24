using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace DataAccessLayer;

public class MongoDbContext : IMongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(IMongoDatabase database)
    {
        _database = database;
        
        Setup();
    }

    private void Setup()
    {
        var pack = new ConventionPack
        {
            new CamelCaseElementNameConvention()
        };

        ConventionRegistry.Register(nameof(CamelCaseElementNameConvention), pack, _ => true);
    }

    public IMongoCollection<TEntity> GetCollection<TEntity>(string collectionName)
    {
        return _database.GetCollection<TEntity>(collectionName);
    }

    public Task<long> CountDocuments<TEntity>(IMongoCollection<TEntity> collection, FilterDefinition<TEntity> filter)
    {
        return collection.CountDocumentsAsync(filter);
    }
}