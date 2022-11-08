using CashFlowTest.Notifications.Notifications.Core;
using MediatR;

namespace CashFlowTest.Notifications.Notifications;

public readonly record struct ExpenseAddNotification : INotification, IBaseNotification
{
    public ExpenseAddNotification(string description, decimal value, DateTime createdDate, DateTime expenseDate, string expenseCategory)
    {
        Description = description;
        Value = value;
        CreatedDate = createdDate;
        ExpenseDate = expenseDate;
        ExpenseCategory = expenseCategory;
    }

    public string Description { get; }
    public decimal Value { get; }
    public DateTime CreatedDate { get; }
    public DateTime ExpenseDate { get; }
    public string ExpenseCategory { get; }
}
