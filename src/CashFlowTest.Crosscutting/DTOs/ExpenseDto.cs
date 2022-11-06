namespace CashFlowTest.Crosscutting.DTOs;

public sealed class ExpenseDto
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public decimal Value { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ExpenseDate { get; set; }
    public Guid ExpenseCategoryId { get; set; }
    public string ExpenseCategory { get; set; }
}
