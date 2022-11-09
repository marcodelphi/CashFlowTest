using CashFlowTest.Command;
using CashFlowTest.Domain.Data;
using CashFlowTest.Domain.Model;
using CashFlowTest.Query;
using CashFlowTest.Services.Implementations;
using CashFlowTest.Notifications;
using CashFlowTest.Domain.Data.CommandContext;

string allowedOriginsPolicy = "SiteCorsPolicy";

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddResponseCompression();

builder.Services.AddCors(options =>
{
    options.AddPolicy(allowedOriginsPolicy, cors =>
    {
        cors.AllowAnyHeader();
        cors.AllowCredentials();
        cors.AllowAnyMethod();
        cors.AllowAnyOrigin();
        cors.AllowAnyOrigin().WithOrigins("http://localhost:4200");
    });
});

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddCashFlowTestDataContext();

builder.Services.AddCommandHandlers();

builder.Services.AddQueryHandlers();

builder.Services.AddNotificationHandlers();

builder.Services.AddAdapters();

builder.Services.AddServices();

WebApplication app = builder.Build();

CancellationToken cancellationToken = new CancellationTokenSource().Token;

app.UseRouting();

app.UseCors(allowedOriginsPolicy);

app.UseAuthorization();

app.MapControllers();

app.UseResponseCompression();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using IServiceScope serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();

CashFlowTestDataContext cashFlowDataContext = serviceScope.ServiceProvider.GetService<CashFlowTestDataContext>();

await cashFlowDataContext.EnsureDataCreatedAsync(cancellationToken);

await app.RunAsync(cancellationToken);
