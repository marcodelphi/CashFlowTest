namespace CashFlowTest.Crosscutting.DTOs;

public struct SummaryDto
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public decimal TotalIncome { get; set; }
    public decimal TotalExpense { get; set; }
    public decimal Balance { get; set; }
}
