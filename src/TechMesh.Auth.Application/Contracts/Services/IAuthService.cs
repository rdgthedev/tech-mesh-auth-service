using TechMesh.Auth.Application.DTOs.Auth.Request;
using TechMesh.Auth.Application.DTOs.Tokens.Response;
using TechMesh.Auth.Application.DTOs.Users;

namespace TechMesh.Auth.Application.Contracts.Services;

public interface IAuthService
{
    Task<AuthTokensResponse> RegisterAsync(RegisterUserRequest userRequest, CancellationToken cancellationToken);
    Task LoginAsync(LoginUserRequest loginUserRequest, CancellationToken cancellationToken);
}