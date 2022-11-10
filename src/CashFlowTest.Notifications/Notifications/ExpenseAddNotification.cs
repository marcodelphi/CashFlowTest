using CashFlowTest.Notifications.Notifications.Core;
using MediatR;

namespace CashFlowTest.Notifications.Notifications;

public readonly record struct ExpenseAddNotification : INotification, IBaseNotification
{
    public ExpenseAddNotification(Guid expenseId, string description, decimal value, DateTime createdDate, DateTime expenseDate, string expenseCategory)
    {
        Id = expenseId;
        Description = description;
        Value = value;
        CreatedDate = createdDate;
        ExpenseDate = expenseDate;
        ExpenseCategory = expenseCategory;
    }

    public Guid Id { get; }
    public string Description { get; }
    public decimal Value { get; }
    public DateTime CreatedDate { get; }
    public DateTime ExpenseDate { get; }
    public string ExpenseCategory { get; }
}
