using Auth_Service.Domain.Base;

namespace Auth_Service.Domain.Interfaces.Repositories;

public interface IRepository<T> where T : Entity
{
    Task<List<T>> GetAsync(CancellationToken cancellationToken);
    Task<T> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task UpdateAsync(CancellationToken cancellationToken);
    Task DeleteAsync(CancellationToken cancellationToken);
}