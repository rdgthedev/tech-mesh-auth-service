using TechMesh.Auth.Application.DTOs.Role.Response;
using TechMesh.Auth.Domain.Entities;

namespace TechMesh.Auth.Application.Mappers;

public static class RoleMapper
{
    public static List<RoleResponse> FromEntities(List<Role> roles)
        => roles.Select(r => new RoleResponse(r.Name, r.Status)).ToList();

    public static RoleResponse FromEntity(Role role)
        => new RoleResponse(role.Name, role.Status);
}