using Entities.Models.Providers.Base;

namespace Entities.Models.Providers.Payload;

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