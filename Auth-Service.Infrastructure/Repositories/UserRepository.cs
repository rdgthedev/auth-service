using Auth_Service.Domain.Interfaces.Repositories;
using Auth_Service.Infrastructure.Data.Context;

namespace Auth_Service.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AuthDbContext _context;

    public UserRepository(AuthDbContext context)
    {
        _context = context;
    }

    public Task<List<User>> GetAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetByEmail(string email, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(User user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(User user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(User user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}