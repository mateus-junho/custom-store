using CustomStore.Core.Data;
using CustomStore.Sales.Data.Contexts;
using CustomStore.Sales.Domain.Constants;
using CustomStore.Sales.Domain.Entities;
using CustomStore.Sales.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomStore.Sales.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly SalesContext context;

        public OrderRepository(SalesContext context)
        {
            this.context = context;
        }

        public IUnitOfWork UnitOfWork => context;

        public void Add(Order order)
        {
            context.Order.Add(order);
        }

        public void AddItem(OrderItem item)
        {
            context.OrderItems.Add(item);
        }

        public async Task<IEnumerable<Order>> GetByClientId(Guid clientId)
        {
            return await context.Order.AsNoTracking().Where(o => o.ClientId == clientId).ToListAsync();
        }

        public async Task<Order> GetById(Guid id)
        {
            return await context.Order.FindAsync(id);
        }

        public async Task<Order> GetDraftOrderByClientId(Guid clientId)
        {
            var order = await context.Order.FirstOrDefaultAsync(o => o.ClientId == clientId && o.OrderStatus == OrderStatus.Draft);

            if (order == null)
            {
                return null;
            }

            await context.Entry(order).Collection(i => i.OrderItems).LoadAsync();

            if (order.VoucherId != null)
            {
                await context.Entry(order).Reference(i => i.Voucher).LoadAsync();
            }

            return order;
        }

        public async Task<OrderItem> GetItemById(Guid id)
        {
            return await context.OrderItems.FindAsync(id);
        }

        public async Task<OrderItem> GetItemByOrder(Guid orderId, Guid productId)
        {
            return await context.OrderItems.FirstOrDefaultAsync(p => p.ProductId == productId && p.OrderId == orderId);
        }

        public async Task<Voucher> GetVoucherByCode(string code)
        {
            return await context.Vouchers.FirstOrDefaultAsync(p => p.Code == code);
        }

        public void RemoveItem(OrderItem item)
        {
            context.OrderItems.Remove(item);
        }

        public void Update(Order order)
        {
            context.Order.Update(order);
        }

        public void UpdateItem(OrderItem item)
        {
            context.OrderItems.Update(item);
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
