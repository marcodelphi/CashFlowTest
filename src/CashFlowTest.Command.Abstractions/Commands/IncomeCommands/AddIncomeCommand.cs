using CashFlowTest.Domain.Model.Entities;

namespace CashFlowTest.Command.Abstractions.Commands.IncomeCommands;

public class AddIncomeCommand : Command<Income>
{
    public AddIncomeCommand(string description, string note, decimal value, DateTime createdDate, DateTime incomeDate)
    {
        Description = description;
        Note = note;
        Value = value;
        CreatedDate = createdDate;
        IncomeDate = incomeDate;
    }

    public string Description { get; }
    public string Note { get; }
    public decimal Value { get; }
    public DateTime CreatedDate { get; }
    public DateTime IncomeDate { get; }
}
