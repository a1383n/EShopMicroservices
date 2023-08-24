using Common.Model.Settings.Global.RateLimit;

namespace Common.Model.Settings.Providers.Phone;

public class PhoneVerificationSuspensionSettings : SuspensionSettings
{
    /// <summary>
    /// Gets or sets whether phone numbers should be suspended when rate limit is exceeded.
    /// </summary>
    public bool SuspendPhoneNumbers { get; set; } = true;
}