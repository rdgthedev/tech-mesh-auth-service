using Microsoft.AspNetCore.Mvc;
using TechMesh.Auth.Application.Contracts.Services;
using TechMesh.Auth.Application.DTOs.Auth.Request;
using TechMesh.Auth.Application.DTOs.Tokens.Response;
using TechMesh.Auth.Application.DTOs.Users;

namespace TechMesh.Auth.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
        => _authService = authService;

    [HttpPost("register")]
    public async Task<ActionResult<AuthTokensResponse>> Register(
        [FromBody] RegisterUserRequest request,
        CancellationToken cancellationToken)
    {
        var response = await _authService.RegisterAsync(request, cancellationToken);

        return StatusCode(201, response);
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login(
        [FromBody] LoginUserRequest loginUserRequest,
        CancellationToken cancellationToken)
    {
        await _authService.LoginAsync(loginUserRequest, cancellationToken);
        return Ok();
    }
}