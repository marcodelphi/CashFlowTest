using CashFlowTest.Domain.Model.Entities;

namespace CashFlowTest.Command.Abstractions.Commands.ExpenseCategoryCommands;

public sealed class AddExpenseCategoryCommand : Command<ExpenseCategory>
{
    public AddExpenseCategoryCommand(string description)
    {
        Description = description;
    }

    public string Description { get; }
}
