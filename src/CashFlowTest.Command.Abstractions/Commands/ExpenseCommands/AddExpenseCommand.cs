using CashFlowTest.Domain.Model.Entities;

namespace CashFlowTest.Command.Abstractions.Commands.ExpenseCommands;

public sealed class AddExpenseCommand: Command<Expense>
{
    public AddExpenseCommand(string description, decimal value, DateTime expenseDate, Guid expenseCategoryId)
    {
        Description = description;
        Value = value;
        ExpenseDate = expenseDate;
        ExpenseCategoryId = expenseCategoryId;
    }

    public string Description { get; set; }
    public decimal Value { get; set; }
    public DateTime ExpenseDate { get; set; }
    public Guid ExpenseCategoryId { get; set; }
}
