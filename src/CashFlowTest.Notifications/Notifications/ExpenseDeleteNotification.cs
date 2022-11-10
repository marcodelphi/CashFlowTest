using CashFlowTest.Notifications.Notifications.Core;
using MediatR;

namespace CashFlowTest.Notifications.Notifications;

public readonly record struct ExpenseDeleteNotification: INotification, IBaseNotification
{
    public ExpenseDeleteNotification(DateTime expenseDate, decimal value)
    {
        ExpenseDate = expenseDate;
        Value = value;
    }

    public DateTime ExpenseDate { get; }
    public decimal Value { get; }
}
