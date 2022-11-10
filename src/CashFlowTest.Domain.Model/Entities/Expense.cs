using System.ComponentModel.DataAnnotations.Schema;

namespace CashFlowTest.Domain.Model.Entities;

public sealed class Expense: BaseEntity, IAggregateRoot<Expense>
{
    public Expense(string description, decimal value, DateTime expenseDate, Guid expenseCategoryId)
    {
        Description = description;
        Value = value;
        CreatedDate = DateTime.Now.ToLocalTime();
        ExpenseDate = expenseDate.ToLocalTime();
        ExpenseCategoryId = expenseCategoryId;
    }

    public string Description { get; set; }
    public decimal Value { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ExpenseDate { get; set; }
    public Guid ExpenseCategoryId { get; set; }

    [ForeignKey("ExpenseCategoryId")]
    public ExpenseCategory ExpenseCategory { get; set; }
}
