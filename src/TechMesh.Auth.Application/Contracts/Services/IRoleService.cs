using TechMesh.Auth.Application.DTOs.Role.Request;
using TechMesh.Auth.Application.DTOs.Role.Response;

namespace TechMesh.Auth.Application.Contracts.Services;

public interface IRoleService
{
    Task<List<RoleResponse>> GetAllAsync(CancellationToken cancellationToken);
    Task<RoleResponse?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task CreateAsync(CreateRoleRequest createRoleRequest, CancellationToken cancellationToken);
    Task UpdateAsync(UpdateRoleRequest updateRoleRequest, CancellationToken cancellationToken);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
}