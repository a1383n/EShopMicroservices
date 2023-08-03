using System.ComponentModel;
using Common;
using CSharpFunctionalExtensions;
using DataAccessLayer.Contracts;
using Entities.Models;
using Entities.Models.Providers.Base;
using Entities.Models.Providers.Info;
using Services.Contracts;
using Services.Contracts.Providers;
using Services.Enums;
using Services.Models;

namespace Services.Implementation;

public class AuthService : IAuthService, ISingletonDependency
{
    private readonly IEmailProvider _emailProvider;

    private readonly IUserRepository _userRepository;
    private readonly ITokenRepository _tokenRepository;
    private readonly IHasher _hasher;

    public AuthService(IEmailProvider emailProvider, ITokenRepository tokenRepository, IUserRepository userRepository, IHasher hasher)
    {
        _emailProvider = emailProvider;
        _tokenRepository = tokenRepository;
        _userRepository = userRepository;
        _hasher = hasher;
    }

    public async Task<Result<User,AuthError>> CreateUserWithEmailAndPassword(string email, string password,
        UserProfile? profile = null)
    {
        var user = new User(new List<ProviderInfo> { new EmailProviderInfo() })
        {
            Email = email,
            Password = _hasher.Make(password)
        };

        try
        {
            await _userRepository.CreateAsync(user);
            return Result.Success<User,AuthError>(user);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return Result.Failure<User,AuthError>(new AuthError(500,e.Message));
        }
    }

    public Task<Result<User,AuthError>> CreateUserWithPayload(ProviderId id, SignInMethod method, IProviderPayload payload)
    {
        throw new NotImplementedException();
    }

    public Task<Result<User,AuthError>> AuthenticateWithPayload(ProviderId id, SignInMethod method, IProviderPayload payload)
    {
        return id switch
        {
            ProviderId.Email => _emailProvider.Authenticate(method, payload),
            _ => throw new InvalidEnumArgumentException($"[{id}] was not exists")
        };
    }

    public async Task<Result<Token,AuthError>> Login(User user, Device device)
    {
        var token = await _tokenRepository.CreateToken(user.Id, device);
        _ = _userRepository.UpdateLastSignInAtAsync(user.Id);
        
        //TODO: Raise Event. For user signIn.
        
        return Result.Success<Token,AuthError>(token);
    }
}