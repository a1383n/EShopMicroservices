namespace Common.Model.Settings.Providers;

public abstract class AuthProviderSetting
{
    public bool IsEnabled { get; set; } = true;
    public bool IsTemporaryDown { get; set; } = false;
}

public class AuthProviderSettings
{
    public PhoneAuthProviderSetting PhoneAuthProviderSetting { get; set; } = new();
}