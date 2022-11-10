using CashFlowTest.Crosscutting.DTOs;
using CashFlowTest.Domain.Model.AdaptersContracts;
using CashFlowTest.Domain.Model.Entities;

namespace CashFlowTest.Domain.Model.Adapters;

public sealed class IncomeAdapter : IIncomeAdapter
{
    public IncomeDto ToDto(Income source) => new IncomeDto(source.Id, source.Description, source.Note, source.Value, source.CreatedDate, source.IncomeDate);

    public Income ToModel(IncomeDto target)
    {
        Income income = new Income
        {
            Id = target.Id,
            Description = target.Description,
            Note = target.Note,
            Value = target.Value
        };
        income.SetIncomeDate(target.IncomeDate);
        return income;
    }
}
