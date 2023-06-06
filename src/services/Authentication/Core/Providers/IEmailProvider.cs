using Core.Enums;

namespace Core.Providers;

public interface IEmailProvider: IAuthProvider
{
    public static readonly ProviderId Id = ProviderId.Email;

    public static readonly List<SignInMethod> AvailableSignInMethods = new() { SignInMethod.Password, SignInMethod.Link, SignInMethod.OneTimePassword };
}