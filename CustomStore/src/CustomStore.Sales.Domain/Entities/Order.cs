using CustomStore.Core.DomainObjects;
using CustomStore.Sales.Domain.Constants;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomStore.Sales.Domain.Entities
{
    public class Order : Entity, IAggregateRoot
    {
        public int Code { get; private set; }

        public Guid ClientId { get; private set; }

        public Guid? VoucherId { get; private set; }

        public bool VoucherApplied { get; private set; }

        public decimal Discount { get; private set; }

        public decimal TotalValue { get; private set; }

        public DateTime RegisterDate { get; private set; }

        public OrderStatus OrderStatus { get; private set; }

        private readonly List<OrderItem> orderItems;

        public IReadOnlyCollection<OrderItem> OrderItems => orderItems;

        public Voucher Voucher { get; private set; }

        public Order(Guid clientId, bool voucherApplied, decimal discount, decimal totalValue)
        {
            ClientId = clientId;
            VoucherApplied = voucherApplied;
            Discount = discount;
            TotalValue = totalValue;
            orderItems = new List<OrderItem>();
        }

        protected Order() 
        {
            orderItems = new List<OrderItem>();
        }

        public void ApplyVoucher(Voucher voucher)
        {
            Voucher = voucher;
            VoucherApplied = true;
            CalculateOrderValue();
        }

        public void CalculateOrderValue()
        {
            TotalValue = OrderItems.Sum(o => o.CalculateValue());
            CalculateDiscountTotalValue();
        }

        public void CalculateDiscountTotalValue()
        {
            if (!VoucherApplied) return;

            decimal discount = 0;
            var value = TotalValue;

            if (Voucher.VoucherDiscountType == VoucherDiscountType.Percentage && Voucher.Percentage.HasValue)
            {
                discount = (value * Voucher.Percentage.Value) / 100;
            }
            else if (Voucher.DiscountValue.HasValue)
            {
                discount = Voucher.DiscountValue.Value;
            }

            value -= discount;

            TotalValue = value < 0 ? 0 : value;
            Discount = discount;
        }

        public bool HasItem(OrderItem item)
        {
            return OrderItems.Any(o => o.ProductId == item.ProductId);
        }

        public void AddItem(OrderItem item)
        {
            if (!item.IsValid()) return;

            item.AssociateOrder(Id);

            if (HasItem(item))
            {
                var existingItem = orderItems.FirstOrDefault(o => o.ProductId == item.ProductId);
                existingItem.AddQuantity(item.Quantity);
                item = existingItem;

                orderItems.Remove(existingItem);
            }

            item.CalculateValue();
            orderItems.Add(item);
        }

        public void RemoveItem(OrderItem item)
        {
            if (!item.IsValid()) return;

            var existingItem = OrderItems.FirstOrDefault(o => o.ProductId == item.ProductId);

            if (existingItem == null)
            {
                throw new DomainException(ExceptionMessages.ItemNotAddedToOrder);
            }
            orderItems.Remove(existingItem);

            CalculateOrderValue();
        }

        public void UpdateItem(OrderItem item)
        {
            if (!item.IsValid()) return;

            var existingItem = OrderItems.FirstOrDefault(o => o.ProductId == item.ProductId);

            if (existingItem == null)
            {
                throw new DomainException(ExceptionMessages.ItemNotAddedToOrder);
            }

            orderItems.Remove(existingItem);
            orderItems.Add(item);

            CalculateOrderValue();
        }

        public void UpdateQuantity(OrderItem item, int quantity)
        {
            item.UpdateQuantity(quantity);
            UpdateItem(item);
        }

        public void MakeDraft()
        {
            OrderStatus = OrderStatus.Draft;
        }

        public void StartOrder()
        {
            OrderStatus = OrderStatus.Started;
        }

        public void FinishOrder()
        {
            OrderStatus = OrderStatus.Payed;
        }

        public void CancelOrder()
        {
            OrderStatus = OrderStatus.Canceled;
        }

        public static class OrderFactory
        {
            public static Order NewDraftOrder(Guid clientId)
            {
                var order = new Order
                {
                    ClientId = clientId,
                };

                order.MakeDraft();
                return order;
            }
        }
    }
}
