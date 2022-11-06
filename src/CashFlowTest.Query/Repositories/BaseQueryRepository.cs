using CashFlowTest.Domain.Model;
using CashFlowTest.Query.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CashFlowTest.Query.Repositories;

public abstract class BaseQueryRepository<TEntity> : IBaseQueryRepository<TEntity> where TEntity : BaseEntity, IAggregateRoot<TEntity>
{
    protected readonly DbContext _context;

    protected DbSet<TEntity> _dbSet;


    public BaseQueryRepository(DbContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    public async Task<TEntity> GetAsync(Guid id, CancellationToken cancellationToken)
        => await _dbSet.Where(expenseCategory => id.Equals(expenseCategory.Id)).FirstOrDefaultAsync(cancellationToken);

    public async Task<TEntity[]> GetAllAsync(CancellationToken cancellationToken)
        => await _dbSet.ToArrayAsync(cancellationToken);

    public IQueryable<TEntity> Queryable() => _dbSet.AsQueryable();
}

