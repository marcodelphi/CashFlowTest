namespace CashFlowTest.Domain.Model.Entities;

public sealed class Income : BaseEntity, IAggregateRoot<Income>
{
    public Income(string description, decimal value)
    {
        Description = description;
        Value = value;
        CreatedDate = DateTime.Now.ToLocalTime();
    }

    public Income()
    {
    }

    public string Description { get; set; }
    public string Note { get; set; }
    public decimal Value { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime IncomeDate { get; private set; }

    public void SetIncomeDate(DateTime date) => IncomeDate = date.ToLocalTime();
}
