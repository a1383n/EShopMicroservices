using Common.Model.Settings.Global;
using Common.Model.Settings.Providers.Phone;

namespace Common.Model.Settings.Providers;

/// <summary>
/// Class representing phone authentication provider settings.
/// </summary>
public class PhoneAuthProviderSetting : AuthProviderSetting
{
    /// <summary>
    /// Gets or sets the settings for phone number verification codes.
    /// </summary>
    public VerificationCodeSettings VerificationCodeSettings { get; set; } = new();

    /// <summary>
    /// Gets or sets the phone verification rate-limiting settings.
    /// </summary>
    public PhoneVerificationRateLimitSettings RateLimitSettings { get; set; } = new();

    /// <summary>
    /// Gets or sets the list of allowed countries for phone verification.
    /// </summary>
    public List<string> AllowedCountries { get; set; } = new();

    /// <summary>
    /// Gets or sets the list of excluded countries for phone verification.
    /// </summary>
    public List<string> ExcludedCountries { get; set; } = new();
}