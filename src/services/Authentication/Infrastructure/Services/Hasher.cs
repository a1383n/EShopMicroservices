using Core.Services;

namespace Infrastructure.Services;

public class Hasher: IHasher
{
    private const int WorkFactor = 11;
    
    public string Make(string value, bool enhancedEntropy = false)
    {
        return BCrypt.Net.BCrypt.HashPassword(value, WorkFactor, enhancedEntropy);
    }

    public bool Verify(string value, string hashedValue, bool enhancedEntropy = false)
    {
        return BCrypt.Net.BCrypt.Verify(value, hashedValue, enhancedEntropy);
    }
}