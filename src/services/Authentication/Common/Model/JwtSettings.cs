namespace Common.Model;

public class JwtSettings
{
    public JwtKey Key { get; set; }
    public TimeSpan NotBeforeMinutes { get; set; } = TimeSpan.Zero;
}