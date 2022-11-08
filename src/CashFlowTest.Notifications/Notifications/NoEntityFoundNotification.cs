using CashFlowTest.Notifications.Notifications.Core;
using MediatR;

namespace CashFlowTest.Notifications.Notifications;

public readonly record struct NoEntityFoundNotification : INotification, IBaseNotification
{
	public NoEntityFoundNotification(Guid entityId, string entityName )
	{
		Id = entityId;
		Name = entityName;
	}

	public Guid Id { get; }
	public string Name { get; }
}
