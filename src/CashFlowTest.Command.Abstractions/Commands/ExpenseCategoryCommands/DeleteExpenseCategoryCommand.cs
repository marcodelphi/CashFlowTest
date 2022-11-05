namespace CashFlowTest.Command.Abstractions.Commands.ExpenseCategoryCommands;

public class DeleteExpenseCategoryCommand : CommandWithId
{
    public DeleteExpenseCategoryCommand(Guid id) : base(id)
    {
    }
}
