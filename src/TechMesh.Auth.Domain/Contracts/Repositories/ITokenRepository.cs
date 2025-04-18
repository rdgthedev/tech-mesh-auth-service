using TechMesh.Auth.Domain.Entities;

namespace TechMesh.Auth.Domain.Contracts.Repositories;

public interface ITokenRepository
{
    Task<Token?> GetByTokenAsync(string token, CancellationToken cancellationToken);
    Task<Token?> GetByUserIdAsync(Guid id, CancellationToken cancellationToken);
    Task CreateAsync(Token token, CancellationToken cancellationToken);
    Task DeleteAsync(Token token, CancellationToken cancellationToken);
}