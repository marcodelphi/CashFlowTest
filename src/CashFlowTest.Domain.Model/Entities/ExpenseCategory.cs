namespace CashFlowTest.Domain.Model.Entities;

public sealed class ExpenseCategory : BaseEntity, IAggregateRoot<ExpenseCategory>
{
    public string Description { get; set; }

    public ExpenseCategory(string description)
    {
        Description = description;
    }
}
