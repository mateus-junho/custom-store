using CustomStore.Core.Communication;
using CustomStore.Core.Messages;
using CustomStore.Core.Messages.CommonMessages.Notifications;
using CustomStore.Sales.Application.Events;
using CustomStore.Sales.Domain.Entities;
using CustomStore.Sales.Domain.Interfaces;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CustomStore.Sales.Application.Commands
{
    public class OrderCommandHandler :
        IRequestHandler<AddOrderItemCommand, bool>
    {
        private readonly IOrderRepository orderRepository;
        private readonly ICustomMediatrHandler customMediatrHandler;

        public OrderCommandHandler(IOrderRepository orderRepository, ICustomMediatrHandler customMediatrHandler)
        {
            this.orderRepository = orderRepository;
            this.customMediatrHandler = customMediatrHandler;
        }

        public async Task<bool> Handle(AddOrderItemCommand request, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(request))
            {
                return false;
            }

            var order = await orderRepository.GetDraftOrderByClientId(request.ClientId);
            var orderItem = new OrderItem(request.ProductId, request.Name, request.Quantity, request.Price);

            if (order == null)
            {
                order = Order.OrderFactory.NewDraftOrder(request.ClientId);
                order.AddItem(orderItem);

                orderRepository.Add(order);
                order.AddEvent(new DraftOrderStartedEvent(order.ClientId, order.Id));
            }
            else
            {
                var orderItemExists = order.HasItem(orderItem);
                order.AddItem(orderItem);

                if (orderItemExists)
                {
                    orderRepository.UpdateItem(order.OrderItems.FirstOrDefault(i => i.ProductId == orderItem.ProductId));
                }
                else
                {
                    orderRepository.AddItem(orderItem);
                }

                order.AddEvent(new OrderUpdatedEvent(order.ClientId, order.Id, order.TotalValue));
            }

            order.AddEvent(new OrderItemAddedEvent(order.ClientId, order.Id, request.ProductId, request.Name, request.Price, request.Quantity));
            return await orderRepository.UnitOfWork.Commit();
        }

        private bool ValidateCommand(Command message)
        {
            if (message.IsValid())
            {
                return true;
            }

            foreach (var error in message.ValidationResult.Errors)
            {
                customMediatrHandler.PublishNotification(new DomainNotification(message.MessageType, error.ErrorMessage));
            }

            return false;
        }
    }
}
