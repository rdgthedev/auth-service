using System.Security.Cryptography;
using Auth_Service.Domain.Interfaces;
using Auth_Service.Domain.Interfaces.Hashing;

namespace Auth_Service.Infrastructure.Services.Hashing;

public class PasswordHashService : IPasswordHashService
{
    private const int _hashSize = 32;
    private const int _saltSize = 16;
    private const int _iterations = 100000;
    private readonly HashAlgorithmName _hashAlgorithmName = HashAlgorithmName.SHA512;

    public string Hash(string password)
    {
        var salt = RandomNumberGenerator.GetBytes(_saltSize);
        var hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, _iterations, _hashAlgorithmName, _hashSize);

        return $"{Convert.ToBase64String(hash)}-{Convert.ToBase64String(salt)}";
    }

    public bool Verify(string password, string passwordHash)
    {
        var parts = passwordHash.Split('-');

        if (parts.Length != 2) 
            throw new Exception("Algo deu errado ao processar sua solicitação. Tente novamente mais tarde.");

        var hash = Convert.FromBase64String(parts[0]);
        var salt = Convert.FromBase64String(parts[1]);

        var newHash = Rfc2898DeriveBytes.Pbkdf2(
            password,
            salt,
            _iterations,
            _hashAlgorithmName,
            _hashSize);

        return CryptographicOperations.FixedTimeEquals(hash, newHash);
    }
}