using CashFlowTest.Command;
using CashFlowTest.Domain.Data;
using CashFlowTest.Domain.Model;
using CashFlowTest.Query;
using CashFlowTest.Services.Implementations;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCashFlowTestDataContext();
builder.Services.AddCommandHandlers();
builder.Services.AddQueryHandlers();
builder.Services.AddAdapters();
builder.Services.AddServices();

WebApplication app = builder.Build();

CancellationToken cancellationToken = new CancellationTokenSource().Token;

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

using IServiceScope serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();

ICashFlowTestDataContext cashFlowDataContext = serviceScope.ServiceProvider.GetService<ICashFlowTestDataContext>();

await cashFlowDataContext.EnsureDataCreatedAsync(cancellationToken);

await app.RunAsync(cancellationToken);
