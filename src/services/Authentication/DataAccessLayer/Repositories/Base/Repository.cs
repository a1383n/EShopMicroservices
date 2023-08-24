using DataAccessLayer.Contracts.Base;
using Entities.Models.Base;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DataAccessLayer.Repositories.Base;

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

    public async Task<TEntity?> GetById(ObjectId id)
    {
        return (await _collection.FindAsync(GetByIdFilter(id))).FirstOrDefault();
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
