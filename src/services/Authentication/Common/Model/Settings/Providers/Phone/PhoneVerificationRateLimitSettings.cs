using Common.Model.Settings.Global.RateLimit;

namespace Common.Model.Settings.Providers.Phone;

public class PhoneVerificationRateLimitSettings: RateLimitSettings
{
    /// <summary>
    /// Gets or sets whether rate limiting should be applied per phone number.
    /// </summary>
    public bool ApplyPerPhoneNumber { get; set; } = true;

    /// <summary>
    /// Gets or sets whether rate limiting should be applied per phone number and IP address combination.
    /// </summary>
    public bool ApplyPerPhoneNumberAndIpAddress { get; set; } = true;

    public PhoneVerificationSuspensionSettings? SuspensionSettings { get; set; } = new();
}