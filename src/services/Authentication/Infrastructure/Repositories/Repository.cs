using Core.Interfaces;
using MongoDB.Driver;

namespace Infrastructure.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
{
    protected readonly IMongoCollection<TEntity> _collection;

    public Repository(IMongoCollection<TEntity> collection)
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
}
