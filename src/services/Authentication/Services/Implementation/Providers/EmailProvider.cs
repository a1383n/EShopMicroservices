using System.ComponentModel;
using Common;
using CSharpFunctionalExtensions;
using DataAccessLayer.Contracts;
using Entities.Models;
using Entities.Models.Providers.Base;
using Entities.Models.Providers.Info;
using Entities.Models.Providers.Payload;
using Services.Contracts;
using Services.Contracts.Providers;
using Services.Enums;
using Services.Models;

namespace Services.Implementation.Providers;

public class EmailProvider : AuthProvider, IEmailProvider, ISingletonDependency
{
    private readonly IHasher _hasher;

    public EmailProvider(IUserRepository userRepository, IHasher hasher) : base(userRepository)
    {
        _hasher = hasher;
    }

    public Task<Result<User,AuthError>> Authenticate(SignInMethod method, IProviderPayload payload)
    {
        var providerPayload = (payload as EmailProviderPayload)!;

        return method switch
        {
            SignInMethod.Password => _authenticateWithPassword(providerPayload.Email, providerPayload.Password!),
            _ => throw new InvalidEnumArgumentException($"[{method}] was not supported in [{GetType()}]")
        };
    }

    private async Task<Result<User,AuthError>> _authenticateWithPassword(string email, string password)
    {
        var user = await _userRepository.GetByEmailAddressAsync(email);
        if (user == null)
            return Result.Failure<User,AuthError>(new(404, "user_not_found", "user_not_found"));

        if (user.Password == null)
            return Result.Failure<User,AuthError>(new(401, "password_not_defined", "password_not_defined"));

        if (!_hasher.Verify(password, user.Password))
            return Result.Failure<User,AuthError>(new(401, "incorrect_password", "incorrect_password"));

        _ = _userRepository.UpdateLastSignInAtAsync(user.Id);
        return Result.Success<User,AuthError>(user);
    }

    public async Task<Result<User,AuthError>> CreateUser(IProviderPayload payload)
    {
        var providerPayload = (payload as EmailProviderPayload)!;

        if (await _userRepository.GetByEmailAddressAsync(providerPayload.Email) != null)
            return Result.Failure<User,AuthError>(new(409, "duplicate_email", "duplicate_email"));

        var user = new User(new List<ProviderInfo> { new EmailProviderInfo() })
        {
            Email = providerPayload.Email,
            Password = _hasher.Make(providerPayload.Password!)
        };
        
        await _userRepository.CreateAsync(user);
        return Result.Success<User,AuthError>(user);
    }
}