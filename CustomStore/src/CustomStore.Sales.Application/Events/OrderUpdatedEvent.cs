using CustomStore.Core.Messages;
using System;

namespace CustomStore.Sales.Application.Events
{
    public class OrderUpdatedEvent : Event
    {
        public Guid ClientId { get; private set; }

        public Guid OrderId { get; private set; }

        public decimal TotalValue { get; private set; }

        public OrderUpdatedEvent(Guid clientId, Guid orderId, decimal totalValue)
        {
            ClientId = clientId;
            OrderId = orderId;
            TotalValue = totalValue;

            AggregateId = orderId;
        }
    }
}
