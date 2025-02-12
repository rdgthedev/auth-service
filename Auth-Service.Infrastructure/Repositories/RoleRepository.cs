using Auth_Service.Domain.Interfaces.Repositories;
using Auth_Service.Infrastructure.Data.Context;

namespace Auth_Service.Infrastructure.Repositories;

public class RoleRepository : IRoleRepository
{
    private readonly AuthDbContext _context;

    public RoleRepository(AuthDbContext context)
    {
        _context = context;
    }

    public Task<List<Role>> GetAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Role> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Role?> GetByName(string name, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(Role role, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Role role, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Role role, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}