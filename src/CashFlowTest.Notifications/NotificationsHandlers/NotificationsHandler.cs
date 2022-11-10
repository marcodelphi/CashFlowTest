using CashFlowTest.Crosscutting.DTOs;
using CashFlowTest.Crosscutting.Enums;
using CashFlowTest.Notifications.Notifications;
using CashFlowTest.Notifications.Notifications.Core;
using CashFlowTest.Services.Abstractions.Services;
using MediatR;
using System.Text.Json;

namespace CashFlowTest.Notifications.NotificationsHandlers;

internal class NotificationsHandler :
    INotificationHandler<NoEntityFoundNotification>,
    INotificationHandler<ExpenseAddNotification>,
    INotificationHandler<ExpenseDeleteNotification>,
    INotificationHandler<IncomeAddNotification>,
    INotificationHandler<IncomeDeleteNotification>
{
    private readonly ICashFlowService _cashFlowService;

    public NotificationsHandler(ICashFlowService cashFlowService)
    {
        _cashFlowService = cashFlowService;
    }

    private static void LogMessage<T>(string message, T data) where T : IBaseNotification
    {
        string log = JsonSerializer.Serialize(data);

        Console.WriteLine($"{message}: {data}");
    }

    public Task Handle(NoEntityFoundNotification notification, CancellationToken cancellationToken)
    {
        LogMessage("Entidade não encontrada:", notification);

        return Task.CompletedTask;
    }

    public Task Handle(ExpenseAddNotification notification, CancellationToken cancellationToken)
    {
        LogMessage("Despesa criada:", notification);

        _cashFlowService.AddExpenseAsync(new SummaryInput(notification.ExpenseDate, notification.Value), cancellationToken);

        return Task.CompletedTask;
    }

    public Task Handle(ExpenseDeleteNotification notification, CancellationToken cancellationToken)
    {
        LogMessage("Despesa excluída:", notification);

        _cashFlowService.DeleteExpenseAsync(new SummaryInput(notification.ExpenseDate, notification.Value), cancellationToken);

        return Task.CompletedTask;
    }

    public Task Handle(IncomeAddNotification notification, CancellationToken cancellationToken)
    {
        LogMessage("Receita criada:", notification);

        _cashFlowService.AddIncomeAsync(new SummaryInput(notification.IncomeDate, notification.Value), cancellationToken);

        return Task.CompletedTask;

    }

    public Task Handle(IncomeDeleteNotification notification, CancellationToken cancellationToken)
    {
        LogMessage("Receita excluída:", notification);

        _cashFlowService.DeleteIncomeAsync(new SummaryInput(notification.IncomeDate, notification.Value), cancellationToken);

        return Task.CompletedTask;
    }
}
