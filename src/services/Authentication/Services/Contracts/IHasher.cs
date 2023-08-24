namespace Services.Contracts;

public interface IHasher
{
    string Make(string value, bool enhancedEntropy = false);
    bool Verify(string value, string hashedValue,bool enhancedEntropy = false);
}