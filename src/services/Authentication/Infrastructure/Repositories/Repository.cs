using Core.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Infrastructure.Repositories;

public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
{
    protected readonly IMongoCollection<TEntity> _collection;

    protected Repository(IMongoCollection<TEntity> collection)
    {
        _collection = collection;
    }

    public Task CreateAsync(TEntity entity)
    {
        return _collection.InsertOneAsync(entity);
    }

    public Task<DeleteResult> DeleteAsync(FilterDefinition<TEntity> filterDefinition)
    {
        return _collection.DeleteOneAsync(filterDefinition);
    }

    public Task<UpdateResult> UpdateAsync(FilterDefinition<TEntity> filterDefinition, UpdateDefinition<TEntity> updateDefinition)
    {
        return _collection.UpdateOneAsync(filterDefinition, updateDefinition);
    }

    protected FilterDefinitionBuilder<TEntity> GetFilterDefinitionBuilder()
    {
        return Builders<TEntity>.Filter;
    }

    public abstract FilterDefinition<TEntity> GetByIdFilter(ObjectId id);

    protected UpdateDefinitionBuilder<TEntity> GetUpdateDefinitionBuilder()
    {
        return Builders<TEntity>.Update;
    }
}
