using Core.Enums;
using Core.Model;
using Core.Model.Provider;

namespace Core.Services;

public interface IAuthService
{
    Task<AuthResult<User>> CreateUserWithEmailAndPassword(string email, string password, UserProfile? profile = null);

    Task<AuthResult<User>> CreateUserWithPayload(ProviderId id, SignInMethod method, IProviderPayload payload);

    Task<AuthResult<User>> LoginWithPayload(ProviderId id, SignInMethod method, IProviderPayload payload);
}