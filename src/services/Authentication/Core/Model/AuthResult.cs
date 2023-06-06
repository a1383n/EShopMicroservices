namespace Core.Model;

public class AuthResult<TResult,TError> where TError: AuthError
{
    public bool IsSuccessful => _result != null && _error == null;

    private readonly TResult? _result;

    private readonly TError? _error;

    protected AuthResult(TResult? result, TError? error)
    {
        _result = result;
        _error = error;
    }

    public static AuthResult<TResult,TError> Successful(TResult result)
    {
        return new(result,default);
    }
    
    public static AuthResult<TResult,TError> Failed(TError error)
    {
        return new(default,error);
    }

    public TResult GetResult()
    {
        return _result!;
    }

    public TError GetError()
    {
        return _error!;
    }
}

public class AuthResult<TResult> : AuthResult<TResult,AuthError>
{
    private AuthResult(TResult? result, AuthError? error) : base(result, error)
    {
    }
    
    public static AuthResult<TResult> Successful(TResult result)
    {
        return new(result, default);
    }
    
    public static AuthResult<TResult> Failed(AuthError error)
    {
        return new(default, error);
    }
}