using Common;
using Services.Contracts;

namespace Services.Implementation;

public class Hasher: IHasher, ISingletonDependency
{
    private const int WorkFactor = 11;
    
    public string Make(string value, bool enhancedEntropy = false)
    {
        //TODO: Bcrypt password hash algorithm design to be slow. This case us performance issue. PBKDF2 or scrypt could be better.
        return BCrypt.Net.BCrypt.HashPassword(value, WorkFactor, enhancedEntropy);
    }

    public bool Verify(string value, string hashedValue, bool enhancedEntropy = false)
    {
        return BCrypt.Net.BCrypt.Verify(value, hashedValue, enhancedEntropy);
    }
}