namespace CashFlowTest.Crosscutting.DTOs;

public sealed class IncomeDto
{
    public IncomeDto(Guid id, string description, string note, decimal value, DateTime createdDate, DateTime incomeDate)
    {
        Id = id;
        Description = description;
        Note = note;
        Value = value;
        CreatedDate = createdDate;
        IncomeDate = incomeDate;
    }

    public Guid Id { get; set; }
    public string Description { get; set; }
    public string Note { get; set; }
    public decimal Value { get; set; }
    public DateTime CreatedDate { get; }
    public DateTime IncomeDate { get; set; }
}
