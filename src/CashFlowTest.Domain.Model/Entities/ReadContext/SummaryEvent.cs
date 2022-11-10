namespace CashFlowTest.Domain.Model.Entities.ReadContext;

public sealed class SummaryEvent : BaseEntity, IAggregateRoot<SummaryEvent>
{
    public SummaryEvent(DateTime eventDate)
    {
        Date = eventDate;
        Id = Guid.NewGuid();
    }

    private SummaryEvent() { }

    public DateTime Date { get; set; }
    public decimal TotalIncome { get; private set; }
    public decimal TotalExpense { get; private set; }
    public decimal Balance => TotalIncome - TotalExpense;


    public SummaryEvent AddExpense(decimal value)
    {
        TotalExpense += value;
        return this;
    }

    public SummaryEvent RemoveExpense(decimal value)
    {
        TotalExpense -= value;
        return this;
    }

    public SummaryEvent AddIncome(decimal value)
    {
        TotalIncome += value;
        return this;
    }

    public SummaryEvent RemoveIncome(decimal value)
    {
        TotalIncome -= value;
        return this;
    }
}