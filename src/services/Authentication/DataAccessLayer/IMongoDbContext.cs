using MongoDB.Driver;

namespace DataAccessLayer;

public interface IMongoDbContext
{
    IMongoCollection<TEntity> GetCollection<TEntity>(string collectionName);

    Task<long> CountDocuments<TEntity>(IMongoCollection<TEntity> collection, FilterDefinition<TEntity> filter);
}