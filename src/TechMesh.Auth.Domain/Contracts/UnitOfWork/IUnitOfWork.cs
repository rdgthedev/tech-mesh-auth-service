namespace TechMesh.Auth.Domain.Contracts.UnitOfWork;

public interface IUnitOfWork
{
    Task CommitAsync(CancellationToken cancellationToken);
}