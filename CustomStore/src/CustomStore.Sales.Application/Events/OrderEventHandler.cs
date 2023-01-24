using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CustomStore.Sales.Application.Events
{
    public class OrderEventHandler :
        INotificationHandler<OrderUpdatedEvent>,
        INotificationHandler<OrderItemAddedEvent>,
        INotificationHandler<DraftOrderStartedEvent>
    {
        public Task Handle(DraftOrderStartedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask; // only called for example propose
        }

        public Task Handle(OrderItemAddedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask; // only called for example propose
        }

        public Task Handle(OrderUpdatedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask; // only called for example propose
        }
    }
}
