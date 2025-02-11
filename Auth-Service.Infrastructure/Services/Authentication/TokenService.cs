namespace Auth_Service.Infrastructure.Services.Authentication;

public class TokenService : ITokenService, IDisposable
{
    private const string _privateKey = "";
    private readonly RSA _rsaKey;

    public TokenService()
        => _rsaKey = RSAKey.Load(_privateKey);

    public string GenerateAccessToken(User user)
    {
        var credentials = new SigningCredentials(
            new RsaSecurityKey(_rsaKey),
            SecurityAlgorithms.RsaSha256);

        var claims = GenerateClaims(user);

        var token = new JwtSecurityToken(
            issuer: "Auth-Service",
            expires: DateTime.Now.AddMinutes(15),
            claims: claims,
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public string GenerateRefreshToken()
    {
        return Guid.NewGuid().ToString();
    }

    public async Task<bool> ValidateAccessToken(string token)
    {
        var validationParameters = GetTokenValidationParameters();

        var principal = await new JwtSecurityTokenHandler().ValidateTokenAsync(token, validationParameters);

        return principal is not null;
    }

    public bool ValidateRefreshToken(RefreshToken refreshToken)
    {
        throw new NotImplementedException();
    }

    public void RevokeRefreshToken(RefreshToken refreshToken)
    {
        throw new NotImplementedException();
    }

    private List<Claim> GenerateClaims(User user)
    {
        return [new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString())];
    }

    private TokenValidationParameters GetTokenValidationParameters()
    {
        return new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateLifetime = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "Auth-Service",
            ValidAudiences = new List<string>(),
            IssuerSigningKey = new RsaSecurityKey(_rsaKey)
        };
    }

    public void Dispose()
    {
        _rsaKey.Dispose();
    }
}