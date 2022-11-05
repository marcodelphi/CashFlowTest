using CashFlowTest.Crosscutting.DTOs;
using CashFlowTest.Domain.Model.Entities;

namespace CashFlowTest.Domain.Model.AdaptersContracts;

public interface IIncomeAdapter: IEntityAdapter<Income, IncomeDto>
{
}