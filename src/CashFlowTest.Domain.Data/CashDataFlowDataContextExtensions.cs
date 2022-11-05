using CashFlowTest.Domain.Model;
using CashFlowTest.Domain.Model.Entities;

namespace CashFlowTest.Domain.Data;

public static class CashDataFlowDataContextExtensions
{
    public static async Task EnsureDataCreatedAsync(this ICashFlowTestDataContext context, CancellationToken cancellationToken)
    {
        await context.Database.EnsureCreatedAsync(cancellationToken);

        AddDefaultExpenseCategories(context);

        await context.SaveChangesAsync(cancellationToken);
    }

    private static void AddDefaultExpenseCategories(ICashFlowTestDataContext context)
    {
        context.ExpenseCategories.AddRange(new ExpenseCategory[]
        {
            new ExpenseCategory("Saúde"),
            new ExpenseCategory("Transporte"),
            new ExpenseCategory("Alimentação"),
            new ExpenseCategory("Educação"),
            new ExpenseCategory("Lazer"),
            new ExpenseCategory("Habitação"),
            new ExpenseCategory("Pessoais"),
            new ExpenseCategory("Outras despesas")
        });
    }
}
