namespace Auth_Service.Application.Interfaces.Hashing;

public interface IPasswordHashService
{
    string Hash(string password);
    bool Verify(string password, string passwordHash);
}