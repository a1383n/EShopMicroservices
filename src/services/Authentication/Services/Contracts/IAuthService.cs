using CSharpFunctionalExtensions;
using Entities.Models;
using Entities.Models.Providers.Base;
using Services.Enums;
using Services.Models;

namespace Services.Contracts;

public interface IAuthService
{
    Task<Result<User,AuthError>> CreateUserWithEmailAndPassword(string email, string password, UserProfile? profile = null);

    Task<Result<User,AuthError>> CreateUserWithPayload(ProviderId id, SignInMethod method, IProviderPayload payload);

    Task<Result<User,AuthError>> AuthenticateWithPayload(ProviderId id, SignInMethod method, IProviderPayload payload);

    Task<Result<Token,AuthError>> Login(User user, Device device);
}