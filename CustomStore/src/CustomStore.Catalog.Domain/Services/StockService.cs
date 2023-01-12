
using CustomStore.Catalog.Domain.Events;
using CustomStore.Catalog.Domain.Interfaces.Repository;
using CustomStore.Catalog.Domain.Interfaces.Services;
using CustomStore.Core.Communication;
using System;
using System.Threading.Tasks;

namespace CustomStore.Catalog.Domain.Services
{
    public class StockService : IStockService
    {
        private readonly IProductRepository productRepository;
        private readonly ICustomMediatrHandler bus;

        private const int ALERT_MIN_STOCK_QUANTITY = 10;

        public StockService(IProductRepository productRepository, ICustomMediatrHandler bus)
        {
            this.productRepository = productRepository;
            this.bus = bus;
        }

        public async Task<bool> AddStock(Guid productId, int quantity)
        {
            var product = await productRepository.GetById(productId);

            if (product == null)
            {
                return false;
            }

            product.AddQuantity(quantity);
            productRepository.Update(product);

            return await productRepository.UnitOfWork.Commit();
        }

        public async Task<bool> DebitStock(Guid productId, int quantity)
        {
            var product = await productRepository.GetById(productId);

            if(product == null || !product.HasQuantityAvailable(quantity))
            {
                return false;
            }

            product.TakeQuantity(quantity);

            if(product.Quantity < ALERT_MIN_STOCK_QUANTITY)
            {
                await bus.PublishEvent(new ProductBelowStockMinEvent(product.Id, product.Quantity));
            }

            productRepository.Update(product);

            return await productRepository.UnitOfWork.Commit();
        }

        public void Dispose()
        {
            productRepository?.Dispose();
        }
    }
}
