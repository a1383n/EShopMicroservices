using Core.Interfaces;

namespace Core.Providers;

public abstract class AuthProvider
{
    protected readonly IUserRepository _userRepository;

    protected AuthProvider(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
}