using MongoDB.Driver;

namespace DataAccessLayer;

public class MongoDbContextFactory
{
    private readonly IMongoClient _mongoClient;

    public MongoDbContextFactory(MongoClientSettings clientSettings)
    {
        _mongoClient = new MongoClient(clientSettings);
    }

    public MongoDbContext Create(string databaseName)
    {
        return new MongoDbContext(_mongoClient.GetDatabase(databaseName));
    }
}