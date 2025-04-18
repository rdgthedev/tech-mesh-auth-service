using TechMesh.Auth.Application.Contracts.Services;
using TechMesh.Auth.Application.DTOs.Role.Request;
using TechMesh.Auth.Application.DTOs.Role.Response;
using TechMesh.Auth.Application.Mappers;
using TechMesh.Auth.Domain.Contracts.Repositories;
using TechMesh.Auth.Domain.Contracts.UnitOfWork;
using TechMesh.Auth.Domain.Entities;

namespace TechMesh.Auth.Application.Services;

public class RoleService : IRoleService
{
    private readonly IRoleRepository _roleRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RoleService(IRoleRepository roleRepository, IUnitOfWork unitOfWork)
    {
        _roleRepository = roleRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<List<RoleResponse>> GetAllAsync(CancellationToken cancellationToken)
    {
        var roles = await _roleRepository.GetAllAsync(cancellationToken);

        if (!roles.Any())
            throw new Exception("Roles not found!");

        return Mapper.Map(roles);
    }

    public async Task<RoleResponse?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var role = await _roleRepository.GetByIdAsync(id, cancellationToken);

        if (role is null)
            throw new Exception("Role not found!");

        return Mapper.Map(role);
    }

    public async Task CreateAsync(CreateRoleRequest createRoleRequest, CancellationToken cancellationToken)
    {
        var role = await _roleRepository.GetByNameAsync(createRoleRequest.Name, cancellationToken);

        if (role is not null)
            throw new Exception("Role already exists");

        await _roleRepository.CreateAsync(new Role(createRoleRequest.Name), cancellationToken);

        await _unitOfWork.CommitAsync(cancellationToken);
    }

    public async Task UpdateAsync(
        Guid id,
        UpdateRoleRequest updateRoleRequest,
        CancellationToken cancellationToken)
    {
        var role = await _roleRepository.GetByIdAsync(id, cancellationToken);

        if (role is null)
            throw new Exception("Role not found!");

        role.ChangeName(updateRoleRequest.Name);

        await _roleRepository.UpdateAsync(role, cancellationToken);

        await _unitOfWork.CommitAsync(cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var role = await _roleRepository.GetByIdAsync(id, cancellationToken);

        if (role is null)
            throw new Exception("Role not found!");

        await _roleRepository.DeleteAsync(role, cancellationToken);

        await _unitOfWork.CommitAsync(cancellationToken);
    }
}