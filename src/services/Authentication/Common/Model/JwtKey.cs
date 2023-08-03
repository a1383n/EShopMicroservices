namespace Common.Model;

public class JwtKey
{
    public string Algorithm { get; set; }

    public string? SecretKey { get; set; }

    public string? PublicKeyPath { get; set; }

    public string? PrivateKeyPath { get; set; }

    public void Validate()
    {
        // if (IsAsymmetric && (string.IsNullOrEmpty(PublicKeyPath) || string.IsNullOrEmpty(PrivateKeyPath)))
        //     throw new InvalidOperationException("Public and private key paths must be set for asymmetric algorithms.");
        //
        // if (!IsAsymmetric && string.IsNullOrEmpty(SecretKey))
        //     throw new InvalidOperationException("Secret key must be set for non-asymmetric algorithms.");
    }
}