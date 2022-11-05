using CashFlowTest.Command.Abstractions.Commands.ExpenseCategoryCommands;
using CashFlowTest.Command.Abstractions.Commands.IncomeCommands;
using CashFlowTest.Crosscutting.DTOs;
using CashFlowTest.Domain.Model.Entities;

namespace CashFlowTest.Services.Abstractions.Services;

public interface IIncomeService : IBaseCrudService<Income, IncomeDto, AddIncomeCommand, UpdateIncomeCommand, DeleteIncomeCommand>
{
    Task<IncomeDto[]> GetAllIncomesAsync(CancellationToken cancellationToken);
}
