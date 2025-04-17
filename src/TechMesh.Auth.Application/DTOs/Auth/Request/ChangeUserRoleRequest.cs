namespace TechMesh.Auth.Application.DTOs.Auth.Request;

public record ChangeUserRoleRequest(
    Guid UserId,
    Guid RoleId);