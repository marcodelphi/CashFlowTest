namespace CashFlowTest.Command.Abstractions.Commands.ExpenseCommands;

public sealed class DeleteExpenseCommand : CommandWithId
{
    public DeleteExpenseCommand(Guid id) : base(id)
    {
    }
}
