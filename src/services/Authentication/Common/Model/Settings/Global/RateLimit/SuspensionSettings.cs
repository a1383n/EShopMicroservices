namespace Common.Model.Settings.Global.RateLimit;

/// <summary>
/// Class to define the suspension settings when rate limit is exceeded.
/// </summary>
public class SuspensionSettings
{
    /// <summary>
    /// Gets or sets whether IP addresses should be suspended when rate limit is exceeded.
    /// </summary>
    public bool SuspendIpAddresses { get; set; } = true;

    /// <summary>
    /// Gets or sets the duration of suspension (in minutes) for phone numbers and IP addresses.
    /// </summary>
    public int SuspensionDurationMinutes { get; set; } = 60;

    /// <summary>
    /// Gets or sets the maximum number of suspensions allowed before banning.
    /// </summary>
    public int MaxSuspensionsBeforeBan { get; set; } = 3;
}