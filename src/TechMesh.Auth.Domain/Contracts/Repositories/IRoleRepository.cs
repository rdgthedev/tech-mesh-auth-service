using TechMesh.Auth.Domain.Entities;

namespace TechMesh.Auth.Domain.Contracts.Repositories;

public interface IRoleRepository
{
    Task<List<Role>> GetAllAsync(CancellationToken cancellationToken);
    Task<Role?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task CreateAsync(Role role, CancellationToken cancellationToken);
    Task UpdateAsync(Role role, CancellationToken cancellationToken);
    Task DeleteAsync(Role role, CancellationToken cancellationToken);
}