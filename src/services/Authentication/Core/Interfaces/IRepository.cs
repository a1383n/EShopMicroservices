using MongoDB.Driver;

namespace Core.Interfaces;

public interface IRepository<TEntity> where TEntity : class, IEntity
{
    Task CreateAsync(TEntity entity);

    Task<UpdateResult> UpdateAsync(FilterDefinition<TEntity> filterDefinition, UpdateDefinition<TEntity> updateDefinition);

    Task<DeleteResult> DeleteAsync(FilterDefinition<TEntity> filterDefinition);
}
