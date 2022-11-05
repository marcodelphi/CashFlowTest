namespace CashFlowTest.Crosscutting.DTOs;

public class ExpenseCategoryDto
{
    public ExpenseCategoryDto(Guid id, string description)
    {
        Id = id;
        Description = description;
    }

    public Guid Id { get; }
    public string Description { get; }
}
