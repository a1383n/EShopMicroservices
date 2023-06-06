namespace Core.Model;

public class AuthError
{
    public int Code;

    public string Error;

    public string ErrorMessage;

    public AuthError(int code, string error, string errorMessage)
    {
        Code = code;
        Error = error;
        ErrorMessage = errorMessage;
    }
}