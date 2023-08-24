using Common.Model;

namespace Services.Models;

public class AuthError: Error
{
    public string? ErrorMessage;

    public AuthError(int statusCode, string error, string? errorMessage = null)
    {
        Title = $"auth.{error}";
        StatusCode = statusCode;
        ErrorMessage = errorMessage;
    }
}