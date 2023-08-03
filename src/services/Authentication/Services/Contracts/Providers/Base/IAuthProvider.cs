using CSharpFunctionalExtensions;
using Entities.Models;
using Entities.Models.Providers.Base;
using Services.Enums;
using Services.Models;

namespace Services.Contracts.Providers.Base;

public interface IAuthProvider
{
    Task<Result<User,AuthError>> Authenticate(SignInMethod method, IProviderPayload payload);

    Task<Result<User,AuthError>> CreateUser(IProviderPayload payload);
}