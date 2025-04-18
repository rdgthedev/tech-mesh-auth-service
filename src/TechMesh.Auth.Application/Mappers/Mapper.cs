using TechMesh.Auth.Application.DTOs.Role.Response;
using TechMesh.Auth.Application.DTOs.Users;
using TechMesh.Auth.Application.DTOs.Users.Response;
using TechMesh.Auth.Domain.Entities;

namespace TechMesh.Auth.Application.Mappers;

public static class Mapper
{
    public static List<RoleResponse> Map(List<Role> roles)
        => roles.Select(r => new RoleResponse(r.Name, r.Status)).ToList();

    public static RoleResponse? Map(Role role) => new(role.Name, role.Status);

    public static List<UserDetailsResponse> Map(List<User> users)
        => users
            .Select(u => new UserDetailsResponse(u.Id, u.Email))
            .ToList();

    public static UserDetailsResponse Map(User user) => new(user.Id, user.Email);

    public static User Map(RegisterUserRequest registerUserRequest)
        => new(registerUserRequest.Email, registerUserRequest.Password);
}