namespace ECommerce.Share.Abstractions.CQRS;

public interface IEventHandler<in TNotification> : INotificationHandler<TNotification>
    where TNotification : IEvent
{
}