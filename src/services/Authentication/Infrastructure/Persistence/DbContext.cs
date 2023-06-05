using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace Infrastructure.Persistence;

public class DbContext
{
    private readonly IMongoDatabase _database;

    public DbContext(string connectionString, string defaultDatabaseName, MongoDatabaseSettings? databaseSettings = null)
    {
        var client = new MongoClient(connectionString);
        _database = client.GetDatabase(defaultDatabaseName, databaseSettings);

        _registerConventions();
    }

    public IMongoCollection<T> GetCollection<T>(string name, MongoCollectionSettings? collectionSettings = null)
    {
        return _database.GetCollection<T>(name,collectionSettings);
    }

    private void _registerConventions()
    {
        var pack = new ConventionPack
        {
            new CamelCaseElementNameConvention()
        };

        ConventionRegistry.Register("LowercaseElementName",pack, type => type.Namespace!.StartsWith("Core.Model"));
    }
}
