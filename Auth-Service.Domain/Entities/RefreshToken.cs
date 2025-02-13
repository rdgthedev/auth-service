using Auth_Service.Domain.Base;

namespace Auth_Service.Domain.Entities;

public class RefreshToken : Entity
{
    public string Token { get; set; }
    public DateTime ExpirationDate { get; set; }
    private bool IsRevoked { get; set; }
    public bool IsValid => Validate();
    public Guid UserId { get; set; }
    public User User { get; set; }

    public RefreshToken(
        string token,
        Guid userId,
        DateTime? expirationDate = null)
    {
        Token = token;
        UserId = userId;
        ExpirationDate = expirationDate ?? DateTime.UtcNow.AddDays(7);
        IsRevoked = false;
    }

    private bool Validate()
        => !IsRevoked || ExpirationDate > DateTime.UtcNow;

    public void Revoke()
        => IsRevoked = true;
}