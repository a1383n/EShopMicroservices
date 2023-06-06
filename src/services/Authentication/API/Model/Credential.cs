using Core.Enums;
using Core.Model.Provider;
using Core.Providers;
using FluentValidation;

namespace API.Model;

public class Credential
{
    public ProviderId? ProviderId { get; set; }

    public SignInMethod? SignInMethod { get; set; }

    public Dictionary<string, string?> Payload { get; set; }

    public IProviderPayload GetPayload()
    {
        return ProviderId! switch
        {
            Core.Enums.ProviderId.Email => new EmailProviderPayload(Payload["email"]!,Payload["password"] ?? null),
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}

public class CredentialValidator : AbstractValidator<Credential>
{
    public CredentialValidator()
    {
        RuleFor(credential => credential.ProviderId)
            .NotNull()
            .IsInEnum()
            .DependentRules(() =>
            {
                RuleFor(credential => credential.SignInMethod)
                    .Cascade(CascadeMode.Stop)
                    .NotNull()
                    .IsInEnum()
                    .Must((credential, signInMethod) =>
                    {
                        return credential.ProviderId switch
                        {
                            ProviderId.Email => IEmailProvider.AvailableSignInMethods.Exists(method => method == signInMethod),
                            _ => throw new ArgumentOutOfRangeException()
                        };
                    })
                    .WithMessage("Invalid SignInMethod for the specified ProviderId.");
            });

        RuleFor(credential => credential.Payload)
            .NotEmpty()
            .When(credential => credential.ProviderId == ProviderId.Email)
            .Must(objects => objects.ContainsKey("email")).WithMessage("Email is required")
            .DependentRules(() =>
            {
                RuleFor(credential => credential.Payload["email"])
                    .NotEmpty()
                    .EmailAddress().WithName("email")
                    .DependentRules(() =>
                    {
                        When(credential => credential.SignInMethod == SignInMethod.Password, () =>
                        {
                            RuleFor(credential => credential.Payload)
                                .Must(objects => objects.ContainsKey("password")).WithMessage("Password is required")
                                .DependentRules(() =>
                                {
                                    RuleFor(credential => credential.Payload["password"])
                                        .NotEmpty()
                                        .MinimumLength(8)
                                        .MaximumLength(32);
                                });
                        });
                    });
            });
    }
}