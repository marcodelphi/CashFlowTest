using CashFlowTest.Crosscutting.DTOs;
using CashFlowTest.Domain.Model.AdaptersContracts;
using CashFlowTest.Domain.Model.Entities;

namespace CashFlowTest.Domain.Model.Adapters;

public sealed class IncomeAdapter : IIncomeAdapter
{
    public IncomeDto ToDto(Income source) => new IncomeDto(source.Id, source.Description, source.Note, source.Value, source.CreatedDate, source.IncomeDate);

    public Income ToModel(IncomeDto target) => new Income
    {
        Id = target.Id,
        Description = target.Description,
        Note = target.Note,
        IncomeDate = target.IncomeDate,
        Value = target.Value
    };
}
