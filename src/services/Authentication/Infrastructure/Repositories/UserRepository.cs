using Core.Interfaces;
using Core.Model;
using Core.Model.Provider;
using Infrastructure.Persistence;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Infrastructure.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(DbContext context) : base(context.GetCollection<User>("users"))
    {
    }

    public override FilterDefinition<User> GetByIdFilter(ObjectId id)
    {
        return GetFilterDefinitionBuilder().Eq(user => user.Id, id);
    }

    public async Task<User?> GetByEmailAddressAsync(string emailAddress)
    {
        return (await _collection.FindAsync(GetFilterDefinitionBuilder().Eq(user => user.Email, emailAddress)))
            .FirstOrDefault();
    }

    public async Task<User?> GetByIdAsync(ObjectId id)
    {
        return (await _collection.FindAsync(GetByIdFilter(id))).FirstOrDefault();
    }

    public async Task<User?> GetByPhoneNumberAsync(string phone)
    {
        return (await _collection.FindAsync(GetFilterDefinitionBuilder().Eq(user => user.Phone, phone)))
            .FirstOrDefault();
    }

    public Task AppendProviderAsync(ObjectId id, ProviderInfo providerInfo)
    {
        throw new NotImplementedException();
    }

    public Task RemoveProviderAsync(ObjectId id, string providerId)
    {
        throw new NotImplementedException();
    }

    public Task SetProfileAsync(ObjectId id, UserProfile profile)
    {
        throw new NotImplementedException();
    }

    public Task SetDisabledAsync(ObjectId id, bool isDisabled = true)
    {
        throw new NotImplementedException();
    }

    public Task UpdateLastSignInAtAsync(ObjectId id)
    {
        return UpdateAsync(
            GetByIdFilter(id),
            GetUpdateDefinitionBuilder().Set(user => user.LastSignInAt,
                new BsonTimestamp(DateTimeOffset.Now.ToUnixTimeSeconds()))
        );
    }

    public Task UpdateLastRefreshAtAsync(ObjectId id)
    {
        throw new NotImplementedException();
    }
}