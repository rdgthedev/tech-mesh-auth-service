using TechMesh.Auth.Domain.Contracts.UnitOfWork;
using TechMesh.Auth.Infrastructure.Database;

namespace TechMesh.Auth.Infrastructure.Persistence.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
        => _context = context;

    public async Task CommitAsync(CancellationToken cancellationToken)
        => await _context.SaveChangesAsync(cancellationToken);
}