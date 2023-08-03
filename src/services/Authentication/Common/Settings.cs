using Common.Model;
using Common.Model.Settings.Providers;

namespace Common;

public class Settings
{
    public int RefreshTokenExpirationDays { get; set; } = 30;

    public TimeSpan AccessTokenExpiration { get; set; } = TimeSpan.FromHours(1);

    public JwtSettings JwtSettings { get; set; }

    public AuthProviderSettings AuthProviderSettings { get; set; } = new();
}