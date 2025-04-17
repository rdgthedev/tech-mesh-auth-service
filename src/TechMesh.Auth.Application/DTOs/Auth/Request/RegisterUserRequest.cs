namespace TechMesh.Auth.Application.DTOs.Users;

public record RegisterUserRequest(
    string FullName,
    string Email,
    string Password);