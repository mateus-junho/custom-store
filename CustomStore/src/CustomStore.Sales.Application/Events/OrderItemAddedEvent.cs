using CustomStore.Core.Messages;
using System;

namespace CustomStore.Sales.Application.Events
{
    public class OrderItemAddedEvent : Event
    {
        public Guid ClientId { get; private set; }

        public Guid OrderId { get; private set; }

        public Guid ProductId { get; private set; }

        public string ProductName { get; private set; }

        public decimal Price { get; private set; }

        public int Quantity { get; private set; }

        public OrderItemAddedEvent(Guid clientId, Guid orderId, Guid productId, string productName, decimal price, int quantity)
        {
            ClientId = clientId;
            OrderId = orderId;
            ProductId = productId;
            ProductName = productName;
            Price = price;
            Quantity = quantity;

            AggregateId = orderId;
        }
    }
}
