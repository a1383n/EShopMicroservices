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

    public Task<User> GetByEmailAddressAsync(string emailAddress)
    {
        throw new NotImplementedException();
    }

    public async Task<User> GetByIdAsync(ObjectId id)
    {
        var filterDefinition = Builders<User>.Filter.Eq(e => e.Id, id);

        return (await _collection.FindAsync(filterDefinition)).FirstOrDefault();
    }

    public Task<User> GetByPhoneNumberAsync(string phone)
    {
        throw new NotImplementedException();
    }

    public Task CreateUser(User user)
    {
        throw new NotImplementedException();
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

    public Task SetLastSignInAtAsync(ObjectId id, DateTime lastSignIn)
    {
        throw new NotImplementedException();
    }

    public Task SetLastRefreshAtAsync(ObjectId id, DateTime lastRefresh)
    {
        throw new NotImplementedException();
    }
}