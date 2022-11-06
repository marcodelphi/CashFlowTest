using CashFlowTest.Crosscutting.DTOs;
using CashFlowTest.Domain.Model.Entities;

namespace CashFlowTest.Domain.Model.AdaptersContracts;

public interface IExpenseAdapter: IEntityAdapter<Expense, ExpenseDto>
{
}