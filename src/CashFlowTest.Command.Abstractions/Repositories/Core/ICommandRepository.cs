using CashFlowTest.Domain.Model;
using System.Linq.Expressions;

namespace CashFlowTest.Command.Abstractions.Repositories.Core;

public interface ICommandRepository<TEntity> where TEntity : BaseEntity, IAggregateRoot<TEntity>
{
    Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken);
    Task<TEntity> AddAsync<TProperty>(TEntity entity, Expression<Func<TEntity, TProperty>> loadExpression, CancellationToken cancellationToken) where TProperty : class;
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
}
