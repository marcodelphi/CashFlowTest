using CashFlowTest.Command.Abstractions.Commands.ExpenseCategoryCommands;
using CashFlowTest.Crosscutting.DTOs;
using CashFlowTest.Domain.Model.Entities;
using CashFlowTest.Services.Abstractions.Services.Core;

namespace CashFlowTest.Services.Abstractions.Services;

public interface IExpenseCategoryService: IBaseCrudService<ExpenseCategory, ExpenseCategoryDto, AddExpenseCategoryCommand, UpdateExpenseCategoryCommand, DeleteExpenseCategoryCommand>
{
    Task<ExpenseCategoryDto[]> GetAllExpenseCategoriesAsync(CancellationToken cancellationToken);
}
