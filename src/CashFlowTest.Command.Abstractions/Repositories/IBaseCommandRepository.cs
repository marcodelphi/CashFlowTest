using CashFlowTest.Domain.Model;

namespace CashFlowTest.Command.Abstractions.Repositories;

public interface IBaseCommandRepository<TEntity>
{
    Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    Task<TEntity> FindForUpdateAsync(Guid id, CancellationToken cancellationToken, Func<TEntity, Task<TEntity>> actionIfExists);
}