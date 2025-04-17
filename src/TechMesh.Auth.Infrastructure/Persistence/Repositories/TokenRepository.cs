using TechMesh.Auth.Domain.Contracts.Repositories;
using TechMesh.Auth.Domain.Entities;

namespace TechMesh.Auth.Infrastructure.Persistence.Repositories;

public class TokenRepository : ITokenRepository
{
    public Task<List<User>> GetAllAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetByTokenValueAsync(Guid token, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task CreateAsync(Token token, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Token token, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Token token, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}