namespace CashFlowTest.Crosscutting.DTOs;

public record SummaryDto
{
    public DateTime Date { get; set; }
    public decimal TotalIncome { get; set; }
    public decimal TotalExpense { get; set; }
    public decimal Balance { get; set; }
}
