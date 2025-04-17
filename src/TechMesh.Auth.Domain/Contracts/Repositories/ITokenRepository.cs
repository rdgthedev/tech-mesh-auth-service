using TechMesh.Auth.Domain.Entities;

namespace TechMesh.Auth.Domain.Contracts.Repositories;

public interface ITokenRepository
{
    Task<List<User>> GetAllAsync(CancellationToken cancellationToken);
    Task<User> GetByTokenValueAsync(Guid token, CancellationToken cancellationToken);
    Task CreateAsync(Token token, CancellationToken cancellationToken);
    Task UpdateAsync(Token token, CancellationToken cancellationToken);
    Task DeleteAsync(Token token, CancellationToken cancellationToken);
}