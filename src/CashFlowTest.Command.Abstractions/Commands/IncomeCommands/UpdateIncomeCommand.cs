using CashFlowTest.Domain.Model.Entities;

namespace CashFlowTest.Command.Abstractions.Commands.IncomeCommands;

public sealed class UpdateIncomeCommand : Command<Income>
{
    public UpdateIncomeCommand(Guid id, string description, string note, decimal value, DateTime incomeDate)
    {
        Id = id;
        Description = description;
        Note = note;
        Value = value;
        IncomeDate = incomeDate;
    }

    public Guid Id { get; }
    public string Description { get;  }
    public string Note { get;  }
    public decimal Value { get;  }
    public DateTime IncomeDate { get;  }
}
