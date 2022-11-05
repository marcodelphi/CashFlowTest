using CashFlowTest.Command.Abstractions.Commands.ExpenseCategoryCommands;
using CashFlowTest.Crosscutting.DTOs;

namespace CashFlowTest.Services.Abstractions.Services;

public interface IExpenseCategoryService
{
    Task<ExpenseCategoryDto> AddExpenseCategoryAsync(AddExpenseCategoryCommand command, CancellationToken cancellationToken);
    Task DeleteExpenseCategoryAsync(DeleteExpenseCategoryCommand command, CancellationToken cancellationToken);
    Task<ExpenseCategoryDto[]> GetAllExpenseCategoriesAsync(CancellationToken cancellationToken);
    Task<ExpenseCategoryDto> UpdateExpenseCategoryAsync(UpdateExpenseCategoryCommand command, CancellationToken cancellationToken);
}
