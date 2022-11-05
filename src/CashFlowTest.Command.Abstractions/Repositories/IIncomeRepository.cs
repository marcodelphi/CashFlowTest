using CashFlowTest.Domain.Model.Entities;

namespace CashFlowTest.Command.Abstractions.Repositories;

public interface IIncomeRepository: ICommandRepository<Income>
{
    Task<Income> UpdateAsync(Guid id, string description, string note, decimal value, DateTime incomeDate, CancellationToken cancellationToken);
}