using CashFlowTest.Domain.Model.Entities;

namespace CashFlowTest.Command.Abstractions.Commands.IncomeCommands;

public sealed class AddIncomeCommand : Command<Income>
{
    public AddIncomeCommand(string description, string note, decimal value, DateTime incomeDate)
    {
        Description = description;
        Note = note;
        Value = value;
        CreatedDate = DateTime.Now;
        IncomeDate = incomeDate;
    }

    private AddIncomeCommand()
    {
        CreatedDate = DateTime.Now;
    }

    public string Description { get; }
    public string Note { get; }
    public decimal Value { get; }
    public DateTime CreatedDate { get; }
    public DateTime IncomeDate { get; }
}
