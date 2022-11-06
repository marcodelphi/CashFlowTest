using System.Linq.Expressions;

namespace CashFlowTest.Command.Abstractions.Repositories.Core;

public interface IBaseCommandRepository<TEntity>
{
    Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken);
    Task<TEntity> AddAsync<TProperty>(TEntity entity, Expression<Func<TEntity, TProperty>> loadExpression, CancellationToken cancellationToken) where TProperty : class;
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    Task<TEntity> FindForUpdateAsync(Guid id, CancellationToken cancellationToken, Func<TEntity, Task<TEntity>> actionIfExists);
}