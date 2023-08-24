namespace Common.Model.Settings.Global.RateLimit;

/// <summary>
/// Class representing static rate limiting settings.
/// </summary>
public class RateLimitSettings
{
    /// <summary>
    /// Gets or sets the maximum number of requests allowed within a specified time window.
    /// </summary>
    public int RequestsLimit { get; set; } = 30;

    /// <summary>
    /// Gets or sets the time window (in seconds) during which the maximum number of requests is allowed.
    /// </summary>
    public int TimeWindowSeconds { get; set; } = 60;

    /// <summary>
    /// Gets or sets whether rate limiting should be applied globally for all clients or per client IP.
    /// </summary>
    public bool ApplyPerClientIp { get; set; } = true;

    /// <summary>
    /// Gets or sets whether to include headers in the response to indicate rate-limiting information.
    /// </summary>
    public bool IncludeRateLimitHeaders { get; set; } = false;

    /// <summary>
    /// Gets or sets the HTTP status code to be returned when rate-limiting is exceeded.
    /// </summary>
    public int RateLimitExceededHttpStatusCode { get; set; } = 429;
    
    /// <summary>
    /// Gets or sets the suspension settings when rate limit is exceeded.
    /// </summary>
    public SuspensionSettings? SuspensionSettings { get; set; }
}