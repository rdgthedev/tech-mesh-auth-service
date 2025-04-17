namespace TechMesh.Auth.Application.DTOs.Tokens.Response;

public record AuthTokensResponse(
    string AccessToken,
    string RefreshToken);