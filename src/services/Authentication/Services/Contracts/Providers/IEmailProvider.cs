using Services.Contracts.Providers.Base;
using Services.Enums;

namespace Services.Contracts.Providers;

public interface IEmailProvider: IAuthProvider
{
    public static readonly ProviderId Id = ProviderId.Email;

    public static readonly List<SignInMethod> AvailableSignInMethods = new() { SignInMethod.Password, SignInMethod.Link, SignInMethod.OneTimePassword };
}