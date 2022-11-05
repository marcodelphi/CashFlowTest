namespace CashFlowTest.Command.Abstractions.Commands.ExpenseCategoryCommands;

public sealed class DeleteExpenseCategoryCommand : CommandWithId
{
    public DeleteExpenseCategoryCommand(Guid id) : base(id)
    {
    }
}
