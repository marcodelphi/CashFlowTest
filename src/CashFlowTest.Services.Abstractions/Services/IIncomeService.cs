using CashFlowTest.Command.Abstractions.Commands.IncomeCommands;
using CashFlowTest.Crosscutting.DTOs;
using CashFlowTest.Domain.Model.Entities;
using CashFlowTest.Services.Abstractions.Services.Core;

namespace CashFlowTest.Services.Abstractions.Services;

public interface IIncomeService : IBaseCrudService<Income, IncomeDto, AddIncomeCommand, UpdateIncomeCommand, DeleteIncomeCommand>
{
    Task<IncomeDto[]> GetAllIncomesAsync(CancellationToken cancellationToken);
}
