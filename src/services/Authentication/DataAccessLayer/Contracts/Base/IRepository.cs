using Entities.Models.Base;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DataAccessLayer.Contracts.Base;

public interface IRepository<TEntity> where TEntity : class, IEntity
{
    Task CreateAsync(TEntity entity);

    Task<TEntity?> GetById(ObjectId id);

    Task<UpdateResult> UpdateAsync(FilterDefinition<TEntity> filterDefinition, UpdateDefinition<TEntity> updateDefinition);

    Task<DeleteResult> DeleteAsync(FilterDefinition<TEntity> filterDefinition);
}
