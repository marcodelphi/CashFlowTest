using CashFlowTest.Domain.Model.Entities;

namespace CashFlowTest.Command.Abstractions.Commands.ExpenseCategoryCommands;

public class UpdateExpenseCategoryCommand : Command<ExpenseCategory>
{
    public UpdateExpenseCategoryCommand(Guid id, string description)
    {
        Id = id;
        Description = description;
    }

    public Guid Id { get; }
    public string Description { get; }
}
