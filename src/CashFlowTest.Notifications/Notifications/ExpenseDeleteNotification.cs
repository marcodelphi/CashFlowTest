using CashFlowTest.Notifications.Notifications.Core;
using MediatR;

namespace CashFlowTest.Notifications.Notifications;

public readonly record struct ExpenseDeleteNotification: INotification, IBaseNotification
{
    public ExpenseDeleteNotification(Guid id, decimal value)
    {
        Id = id;
        Value = value;
    }

    public Guid Id { get; }
    public decimal Value { get; }
}
