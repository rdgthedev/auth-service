using Auth_Service.Domain.Interfaces.Repositories;

namespace Auth_Service.Domain.Interfaces.Transaction;

public interface IUnitOfWork
{
    public IUserRepository Users { get; }
    public IRoleRepository Roles { get; }
    public IRefreshTokenRepository RefreshTokens { get; set; }
    Task CommitAsync();
}