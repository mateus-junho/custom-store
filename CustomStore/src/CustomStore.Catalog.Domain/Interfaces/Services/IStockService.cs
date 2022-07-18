
using System;
using System.Threading.Tasks;

namespace CustomStore.Catalog.Domain.Interfaces.Services
{
    public interface IStockService : IDisposable
    {
        Task<bool> DebitStock(Guid productId, int quantity);

        Task<bool> AddStock(Guid productId, int quantity);
    }
}
