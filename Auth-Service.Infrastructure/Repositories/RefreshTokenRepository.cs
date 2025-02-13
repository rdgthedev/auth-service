namespace Auth_Service.Infrastructure.Repositories;

public class RefreshTokenRepository(AuthDbContext context) : IRefreshTokenRepository
{
    public Task<RefreshToken?> GetByRefreshTokenValue(string refreshToken, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(RefreshToken token, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}