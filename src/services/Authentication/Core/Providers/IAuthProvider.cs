using Core.Enums;
using Core.Model;
using Core.Model.Provider;

namespace Core.Providers;

public interface IAuthProvider
{
    Task<AuthResult<User>> Authenticate(SignInMethod method, IProviderPayload payload);

    Task<AuthResult<User>> CreateUser(IProviderPayload payload);
}