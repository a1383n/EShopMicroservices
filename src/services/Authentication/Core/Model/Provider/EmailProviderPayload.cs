namespace Core.Model.Provider;

public class EmailProviderPayload: IProviderPayload
{
    public readonly string Email;

    public readonly string? Password;

    public EmailProviderPayload(string email, string? password = null)
    {
        Email = email;
        Password = password;
    }
}