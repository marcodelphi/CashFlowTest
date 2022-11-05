namespace CashFlowTest.Domain.Model.Entities;

public sealed class Income : BaseEntity, IAggregateRoot<Income>
{
    public Income(string description, decimal value)
    {
        Description = description;
        Value = value;
        CreatedDate = DateTime.Now;
    }

    public string Description { get; }
    public string Note { get; set; }
    public decimal Value { get; }
    public DateTime CreatedDate { get; set; }
    public DateTime IncomeDate { get; set; }
}
