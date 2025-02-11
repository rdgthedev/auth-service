using Auth_Service.Domain.Entities;

namespace Auth_Service.Domain.Interfaces.Repositories;

public interface IRoleRepository
{
    Task<List<Role>> GetAsync(CancellationToken cancellationToken);
    Task<Role> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<Role?> GetByName(string name, CancellationToken cancellationToken);
    Task AddAsync(Role role, CancellationToken cancellationToken);
    Task UpdateAsync(Role role, CancellationToken cancellationToken);
    Task DeleteAsync(Role role, CancellationToken cancellationToken);
}