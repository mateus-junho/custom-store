
using CustomStore.Core.DomainObjects;
using System;

namespace CustomStore.Sales.Domain.Entities
{
    public class OrderItem : Entity
    {
        public Guid OrderId { get; private set; }

        public Guid ProductId { get; private set; }

        public string ProductName { get; private set; }

        public int Quantity { get; private set; }

        public decimal UnitaryValue { get; private set; }

        public Order Order { get; set; }

        public OrderItem(Guid productId, string productName, int quantity, decimal unitaryValue)
        {
            ProductId = productId;
            ProductName = productName;
            Quantity = quantity;
            UnitaryValue = unitaryValue;
        }

        protected OrderItem() { }

        internal void AssociateOrder(Guid orderId)
        {
            OrderId = orderId;
        }

        public decimal CalculateValue()
        {
            return UnitaryValue * Quantity;
        }

        internal void AddQuantity(int quantity)
        {
            Quantity += quantity;
        }

        internal void UpdateQuantity(int quantity)
        {
            Quantity = quantity;
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}
