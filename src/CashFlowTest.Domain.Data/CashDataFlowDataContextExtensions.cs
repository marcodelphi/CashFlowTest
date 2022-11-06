using CashFlowTest.Domain.Model.Entities;

namespace CashFlowTest.Domain.Data;

public static class CashDataFlowDataContextExtensions
{
    public static async Task EnsureDataCreatedAsync(this CashFlowTestDataContext context, CancellationToken cancellationToken)
    {
        await context.Database.EnsureCreatedAsync(cancellationToken);

        AddDefaultExpenseCategories(context);

        await context.SaveChangesAsync(cancellationToken);
    }

    private static void AddDefaultExpenseCategories(CashFlowTestDataContext context)
    {
        context.ExpenseCategories.AddRange(new ExpenseCategory[]
        {
            new ExpenseCategory(Guid.Parse("238b3c06-a308-4ab8-9449-3d14845d0f34"), "Saúde"),
            new ExpenseCategory(Guid.Parse("be3bf734-41d3-42bf-989f-e8f9086987ac"), "Transporte"),
            new ExpenseCategory(Guid.Parse("9e78800e-f830-4681-a6c1-7878716d80bd"), "Alimentação"),
            new ExpenseCategory(Guid.Parse("f43c2697-8249-4b45-9562-221d280d0f15"), "Educação"),
            new ExpenseCategory(Guid.Parse("d3a797cb-9125-441b-b6fb-b6b742621801"),"Lazer"),
            new ExpenseCategory(Guid.Parse("0e6313d9-5e90-45cf-a898-751661123cf7"),"Habitação"),
            new ExpenseCategory(Guid.Parse("da6010ad-ce4d-46be-b820-dad897835f43"),"Pessoais"),
            new ExpenseCategory(Guid.Parse("ada879bf-4725-4203-80b7-7cd3cf1a69dd"),"Outras despesas")
        });
    }
}
    
    
    
    
