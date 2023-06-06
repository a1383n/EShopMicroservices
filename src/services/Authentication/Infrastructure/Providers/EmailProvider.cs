using System.ComponentModel;
using Core.Enums;
using Core.Interfaces;
using Core.Model;
using Core.Model.Provider;
using Core.Providers;
using Core.Services;

namespace Infrastructure.Providers;

public class EmailProvider : AuthProvider, IEmailProvider
{
    private readonly IHasher _hasher;

    public EmailProvider(IUserRepository userRepository, IHasher hasher) : base(userRepository)
    {
        _hasher = hasher;
    }

    public Task<AuthResult<User>> Authenticate(SignInMethod method, IProviderPayload payload)
    {
        var providerPayload = (payload as EmailProviderPayload)!;

        return method switch
        {
            SignInMethod.Password => _authenticateWithPassword(providerPayload.Email, providerPayload.Password!),
            _ => throw new InvalidEnumArgumentException($"[{method}] was not supported in [{GetType()}]")
        };
    }

    private async Task<AuthResult<User>> _authenticateWithPassword(string email, string password)
    {
        var user = await _userRepository.GetByEmailAddressAsync(email);
        if (user == null)
            return AuthResult<User>.Failed(new(404, "user_not_found", "user_not_found"));

        if (user.Password == null)
            return AuthResult<User>.Failed(new(401, "password_not_defined", "password_not_defined"));

        if (!_hasher.Verify(password, user.Password))
            return AuthResult<User>.Failed(new(401, "incorrect_password", "incorrect_password"));

        _ = _userRepository.UpdateLastSignInAtAsync(user.Id);
        return AuthResult<User>.Successful(user);
    }

    public async Task<AuthResult<User>> CreateUser(IProviderPayload payload)
    {
        var providerPayload = (payload as EmailProviderPayload)!;

        if (await _userRepository.GetByEmailAddressAsync(providerPayload.Email) != null)
            return AuthResult<User>.Failed(new(409, "duplicate_email", "duplicate_email"));

        var user = new User(new List<ProviderInfo> { new EmailProviderInfo() })
        {
            Email = providerPayload.Email,
            Password = _hasher.Make(providerPayload.Password!)
        };
        
        await _userRepository.CreateAsync(user);
        return AuthResult<User>.Successful(user);
    }
}