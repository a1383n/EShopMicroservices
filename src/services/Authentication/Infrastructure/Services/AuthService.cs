using System.ComponentModel;
using Core.Enums;
using Core.Model;
using Core.Model.Provider;
using Core.Providers;
using Core.Services;

namespace Infrastructure.Services;

public class AuthService : IAuthService
{
    private readonly IEmailProvider _emailProvider;

    public AuthService(IEmailProvider emailProvider)
    {
        _emailProvider = emailProvider;
    }

    public Task<AuthResult<User>> CreateUserWithEmailAndPassword(string email, string password,
        UserProfile? profile = null)
    {
        throw new NotImplementedException();
    }

    public Task<AuthResult<User>> CreateUserWithPayload(ProviderId id, SignInMethod method, IProviderPayload payload)
    {
        throw new NotImplementedException();
    }

    public Task<AuthResult<User>> LoginWithPayload(ProviderId id, SignInMethod method, IProviderPayload payload)
    {
        return id switch
        {
            ProviderId.Email => _emailProvider.Authenticate(method, payload),
            _ => throw new InvalidEnumArgumentException($"[{id}] was not exists")
        };
    }
}