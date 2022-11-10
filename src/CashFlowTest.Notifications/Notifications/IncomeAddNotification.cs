using CashFlowTest.Notifications.Notifications.Core;
using MediatR;

namespace CashFlowTest.Notifications.Notifications;

public readonly record struct IncomeAddNotification : INotification, IBaseNotification
{
    public IncomeAddNotification(Guid id, string description, string note, decimal value, DateTime createdDate, DateTime incomeDate)
    {
        Id = id;
        Description = description;
        Note = note;
        Value = value;
        CreatedDate = createdDate;
        IncomeDate = incomeDate;
    }

    public Guid Id { get; }
    public string Description { get;  }
    public string Note { get; }
    public decimal Value { get; }
    public DateTime CreatedDate { get;  }
    public DateTime IncomeDate { get;  }
}
