using TechMesh.Auth.Application.DTOs.Users.Response;
using TechMesh.Auth.Domain.Entities;

namespace TechMesh.Auth.Application.Mappers;

public static class UserMapper
{
    public static List<UserDetailsResponse> FromEntities(List<User> users)
    {
        return users
            .Select(u => new UserDetailsResponse(u.Id, u.Email))
            .ToList();
    }

    public static UserDetailsResponse FromEntity(User user)
    {
        return new UserDetailsResponse(user.Id, user.Email);
    }
}