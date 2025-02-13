using Microsoft.Extensions.Options;

namespace Auth_Service.Infrastructure.Services.Authentication;

public class TokenService(IOptions<JwtSettings> options) : ITokenService
{
    private readonly JwtSettings _options = options.Value;

    public string GenerateAccessToken(User user)
    {
        using var privateKey = RSAKey.Load(_options.PrivateKey);

        var credentials = new SigningCredentials(
            new RsaSecurityKey(privateKey),
            SecurityAlgorithms.RsaSha256);

        var claims = GenerateClaims(user);

        var token = new JwtSecurityToken(
            issuer: _options.Issuer,
            expires: DateTime.Now.AddMinutes(_options.ExpirationTimeInMinutes),
            claims: claims,
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public string GenerateRefreshToken() => Guid.NewGuid().ToString();

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
        using var publicKey = RSAKey.Load(_options.PublicKey);

        return new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateLifetime = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = _options.Issuer,
            ValidAudiences = _options.Audiences,
            IssuerSigningKey = new RsaSecurityKey(publicKey)
        };
    }
}