namespace CashFlowTest.Crosscutting.DTOs;

public readonly record struct SummaryInput
{
    public SummaryInput(DateTime eventDate, decimal value)
    {
        EventDate = eventDate.ToLocalTime().Date;
        Value = value;
    }

    public DateTime EventDate { get;  }
    public decimal Value { get;  }
}