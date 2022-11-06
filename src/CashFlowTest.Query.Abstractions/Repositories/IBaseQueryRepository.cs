using CashFlowTest.Domain.Model;

namespace CashFlowTest.Query.Abstractions.Repositories;

public interface IBaseQueryRepository<TEntity> where TEntity: BaseEntity, IAggregateRoot<TEntity>{
    Task<TEntity[]> GetAllAsync(CancellationToken cancellationToken);
    Task<TEntity> GetAsync(Guid id, CancellationToken cancellationToken);
    IQueryable<TEntity> Queryable();
}