using CashFlowTest.Command.Abstractions.Repositories.Core;
using CashFlowTest.Domain.Model.Entities;

namespace CashFlowTest.Command.Abstractions.Repositories;

public interface IIncomeRepository: ICommandRepository<Income>, ICommandRepositoryGetEntity<Income>
{
    Task<Income> UpdateAsync(Guid id, string description, string note, decimal value, DateTime incomeDate, CancellationToken cancellationToken);
}