using CashFlowTest.Domain.Model.Entities;

namespace CashFlowTest.Command.Abstractions.Commands.ExpenseCommands;

public sealed class UpdateExpenseCommand: Command<Expense>
{
    public UpdateExpenseCommand(Guid id, string description, decimal value, DateTime expenseDate, Guid expenseCategoryId)
    {
        Id = id;
        Description = description;
        Value = value;
        ExpenseDate = expenseDate;
        ExpenseCategoryId = expenseCategoryId;
    }

    public Guid Id { get; set; }
    public string Description { get; set; }
    public decimal Value { get; set; }
    public DateTime ExpenseDate { get; set; }
    public Guid ExpenseCategoryId { get; set; }
}
