using CashFlowTest.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace CashFlowTest.Query.Abstractions.Repositories;

public interface IBaseQueryRepository<TEntity> where TEntity: BaseEntity, IAggregateRoot<TEntity>{
    DbSet<TEntity> DbSet { get; }
    Task<TEntity[]> GetAllAsync(CancellationToken cancellationToken);
    Task<TEntity> GetAsync(Guid id, CancellationToken cancellationToken);
    IQueryable<TEntity> Queryable();
}