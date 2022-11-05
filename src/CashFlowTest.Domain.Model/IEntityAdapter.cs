namespace CashFlowTest.Domain.Model;

public interface IEntityAdapter<TSource, TTarget>
    where TSource : BaseEntity
    where TTarget : class
{
    TTarget ToDto(TSource source);
    TSource ToModel(TTarget target);
}
