namespace CashFlowTest.Command.Abstractions.Commands.IncomeCommands;

public class DeleteIncomeCommand : CommandWithId
{
    public DeleteIncomeCommand(Guid id) : base(id)
    {
    }
}
