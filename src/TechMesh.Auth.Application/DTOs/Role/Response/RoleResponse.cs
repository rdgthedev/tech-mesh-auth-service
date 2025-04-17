using TechMesh.Auth.Domain.Enums;

namespace TechMesh.Auth.Application.DTOs.Role.Response;

public record RoleResponse(
    string Name,
    ERoleStatus Status);