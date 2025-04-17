using TechMesh.Auth.Application.DTOs.Auth.Request;
using TechMesh.Auth.Application.DTOs.Users;
using TechMesh.Auth.Application.DTOs.Users.Response;

namespace TechMesh.Auth.Application.Contracts.Services;

public interface IUserService
{
    Task<List<UserDetailsResponse>> GetAllAsync(CancellationToken cancellationToken);
    Task<UserDetailsResponse> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task UpdateAsync(UpdateUserRequest user, CancellationToken cancellationToken);
    Task DeactivateAsync(Guid id, CancellationToken cancellationToken);
    Task ActivateAsync(Guid id, CancellationToken cancellationToken);
    Task ChangeRoleAsync(ChangeUserRoleRequest changeUserRoleRequest, CancellationToken cancellationToken);
}