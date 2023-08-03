using DataAccessLayer.Contracts.Base;
using Entities.Models;
using Entities.Models.Providers.Base;
using MongoDB.Bson;

namespace DataAccessLayer.Contracts;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetByIdAsync(ObjectId id);
    Task<User?> GetByEmailAddressAsync(string emailAddress);
    Task<User?> GetByPhoneNumberAsync(string phone);
    Task AppendProviderAsync(ObjectId id, ProviderInfo providerInfo);
    Task RemoveProviderAsync(ObjectId id, string providerId);
    Task SetProfileAsync(ObjectId id, UserProfile profile);
    Task SetDisabledAsync(ObjectId id, bool isDisabled = true);
    Task UpdateLastSignInAtAsync(ObjectId id);
    Task UpdateLastRefreshAtAsync(ObjectId id);
}
