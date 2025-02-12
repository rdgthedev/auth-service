using Auth_Service.Domain.Interfaces.Repositories;
using Auth_Service.Infrastructure.Data.Context;

namespace Auth_Service.Infrastructure.Repositories;

public class RefreshTokenRepository : IRefreshTokenRepository
{
    private readonly AuthDbContext _context;

    public RefreshTokenRepository(AuthDbContext context)
    {
        _context = context;
    }

    public Task<RefreshToken?> GetByRefreshTokenValue(string refreshToken, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(RefreshToken token, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}