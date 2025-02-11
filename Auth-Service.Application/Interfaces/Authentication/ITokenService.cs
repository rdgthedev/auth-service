using Auth_Service.Domain.Entities;

namespace Auth_Service.Application.Interfaces.Authentication;

public interface ITokenService
{
    string GenerateAccessToken(User user);
    string GenerateRefreshToken();
    Task<bool> ValidateAccessToken(string token);
    bool ValidateRefreshToken(RefreshToken refreshToken);
    void RevokeRefreshToken(RefreshToken refreshToken);
}