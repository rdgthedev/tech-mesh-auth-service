using TechMesh.Auth.Application.Contracts.Services;
using TechMesh.Auth.Application.DTOs.Auth.Request;
using TechMesh.Auth.Application.DTOs.Tokens.Response;
using TechMesh.Auth.Application.DTOs.Users;
using TechMesh.Auth.Domain.Contracts.Repositories;
using TechMesh.Auth.Domain.Entities;

namespace TechMesh.Auth.Infrastructure.Services.Auth;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;

    public AuthService(IUserRepository userRepository)
        => _userRepository = userRepository;

    public async Task<AuthTokensResponse> RegisterAsync(RegisterUserRequest userRequest,
        CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmail(userRequest.Email, cancellationToken);

        if (user is not null)
            throw new Exception("User already exists!");

        //criptografar a senha

        await _userRepository.CreateAsync(new User(userRequest.Email, userRequest.Password), cancellationToken);

        //chamar endpoint /api/users/create -> User Service

        //gerar tokens

        return new AuthTokensResponse("", "");
    }

    public Task LoginAsync(LoginUserRequest loginUserRequest, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}