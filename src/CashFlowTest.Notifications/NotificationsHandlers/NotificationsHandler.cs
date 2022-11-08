using CashFlowTest.Notifications.Notifications;
using CashFlowTest.Notifications.Notifications.Core;
using MediatR;
using System.Text.Json;

namespace CashFlowTest.Notifications.NotificationsHandlers;

internal class NotificationsHandler : 
    INotificationHandler<ExpenseAddNotification>,
    INotificationHandler<NoEntityFoundNotification>,
    INotificationHandler<ExpenseDeleteNotification>
{
    private static void LogMessage<T>(string message, T data) where T: IBaseNotification
    {
        string log = JsonSerializer.Serialize(data);

        Console.WriteLine($"{message}: {data}");
    }

    public Task Handle(ExpenseAddNotification notification, CancellationToken cancellationToken)
    {
        LogMessage("Despesa criada:", notification);

        return Task.CompletedTask;
    }

    public Task Handle(NoEntityFoundNotification notification, CancellationToken cancellationToken)
    {
        LogMessage("Entidade não encontrada:", notification);

        return Task.CompletedTask;
    }

    public Task Handle(ExpenseDeleteNotification notification, CancellationToken cancellationToken)
    {
        LogMessage("Despesa excluída:", notification);

        return Task.CompletedTask;
    }
}
