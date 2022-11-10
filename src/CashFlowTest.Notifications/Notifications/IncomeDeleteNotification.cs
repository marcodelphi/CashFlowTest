using CashFlowTest.Notifications.Notifications.Core;
using MediatR;

namespace CashFlowTest.Notifications.Notifications;

public readonly record struct IncomeDeleteNotification: INotification, IBaseNotification
{
    public IncomeDeleteNotification(DateTime incomeDate, decimal value)
    {
        IncomeDate = incomeDate;
        Value = value;
    }

    public DateTime IncomeDate { get; }
    public decimal Value { get; }
}
