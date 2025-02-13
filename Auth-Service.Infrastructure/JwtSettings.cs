namespace Auth_Service.Infrastructure;

public class JwtSettings
{
    public string PrivateKey { get; set; } = string.Empty;
    public string PublicKey { get; set; } = string.Empty;
    public int ExpirationTimeInMinutes { get; set; }
    public string Issuer { get; set; } = string.Empty;
    public List<string> Audiences { get; set; } = null!;
}