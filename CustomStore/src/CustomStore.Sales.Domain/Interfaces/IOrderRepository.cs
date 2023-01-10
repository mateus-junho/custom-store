
using CustomStore.Core.Data;
using CustomStore.Sales.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomStore.Sales.Domain.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<Order> GetById(Guid id);
        Task<IEnumerable<Order>> GetByClientId(Guid clientId);
        Task<Order> GetDraftOrderByClientId(Guid clientId);
        void Add(Order order);
        void Update(Order order);

        Task<OrderItem> GetItemById(Guid id);
        Task<OrderItem> GetItemByOrder(Guid orderId, Guid productId);
        void AddItem(OrderItem item);
        void UpdateItem(OrderItem item);
        void RemoveItem(OrderItem item);

        Task<Voucher> GetVoucherByCode(string code);
    }
}
