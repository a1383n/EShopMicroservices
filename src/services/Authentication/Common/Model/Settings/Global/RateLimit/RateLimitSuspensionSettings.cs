namespace Common.Model.Settings.Global.RateLimit;

/// <summary>
/// Class to define the suspension settings when rate limit is exceeded.
/// </summary>
public class RateLimitSuspensionSettings
{
    /// <summary>
    /// Gets or sets whether phone numbers should be suspended when rate limit is exceeded.
    /// </summary>
    public bool SuspendNumbersAndEmails { get; set; }

    /// <summary>
    /// Gets or sets whether IP addresses should be suspended when rate limit is exceeded.
    /// </summary>
    public bool SuspendIpAddresses { get; set; }

    /// <summary>
    /// Gets or sets the duration of suspension (in minutes) for phone numbers and IP addresses.
    /// </summary>
    public int SuspensionDurationMinutes { get; set; } = 60;

    /// <summary>
    /// Gets or sets the maximum number of suspensions allowed before banning permanently.
    /// </summary>
    public int MaxSuspensionsBeforeBan { get; set; } = 5;
}