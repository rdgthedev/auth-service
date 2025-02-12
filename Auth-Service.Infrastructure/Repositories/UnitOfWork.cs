using Auth_Service.Domain.Interfaces.Repositories;
using Auth_Service.Infrastructure.Data.Context;

namespace Auth_Service.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly AuthDbContext _context;
    private IUserRepository _userRepository;
    private IRoleRepository _roleRepository;
    private IRefreshTokenRepository _refreshTokenRepository;

    public UnitOfWork(
        AuthDbContext context,
        IUserRepository userRepository,
        IRoleRepository roleRepository,
        IRefreshTokenRepository refreshTokenRepository
    )
    {
        _context = context;
        _userRepository = userRepository;
        _roleRepository = roleRepository;
        _refreshTokenRepository = refreshTokenRepository;
    }

    public IUserRepository Users => _userRepository ??= new UserRepository(_context);
    public IRoleRepository Roles => _roleRepository ??= new RoleRepository(_context);
    public IRefreshTokenRepository RefreshTokens => _refreshTokenRepository ??= new RefreshTokenRepository(_context);

    public async Task CommitAsync(CancellationToken cancellationToken)
        => await _context.SaveChangesAsync(cancellationToken);

    public void Dispose()
        => _context.Dispose();
}