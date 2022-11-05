namespace CashFlowTest.Command.Abstractions.Commands.IncomeCommands;

public sealed class DeleteIncomeCommand : CommandWithId
{
    public DeleteIncomeCommand(Guid id) : base(id)
    {
    }
}
