using DataAccessLayer.Contracts;

namespace Services.Implementation.Providers;

public abstract class AuthProvider
{
    protected readonly IUserRepository _userRepository;

    protected AuthProvider(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
}