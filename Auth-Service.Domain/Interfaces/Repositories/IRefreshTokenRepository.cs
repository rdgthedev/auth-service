using Auth_Service.Domain.Entities;

namespace Auth_Service.Domain.Interfaces.Repositories;

public interface IRefreshTokenRepository
{
    Task<RefreshToken?> GetByRefreshTokenValue(string refreshToken, CancellationToken cancellationToken);
    Task DeleteAsync(RefreshToken token, CancellationToken cancellationToken);
}