using TechMesh.Auth.Application.Contracts.Services;
using TechMesh.Auth.Application.DTOs.Role.Request;
using TechMesh.Auth.Application.DTOs.Role.Response;
using TechMesh.Auth.Domain.Contracts.Repositories;

namespace TechMesh.Auth.Application.Services;

public class RoleService : IRoleService
{
    private readonly IRoleRepository _roleRepository;

    public RoleService()
    {
    }
    
    public Task<List<RoleResponse>> GetAllAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<RoleResponse?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task CreateAsync(CreateRoleRequest createRoleRequest, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(UpdateRoleRequest updateRoleRequest, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}