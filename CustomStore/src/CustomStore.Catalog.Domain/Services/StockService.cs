
using CustomStore.Catalog.Domain.Interfaces.Repository;
using CustomStore.Catalog.Domain.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace CustomStore.Catalog.Domain.Services
{
    public class StockService : IStockService
    {
        private readonly IProductRepository productRepository;

        public StockService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
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
            productRepository.Update(product);

            return await productRepository.UnitOfWork.Commit();
        }

        public void Dispose()
        {
            productRepository?.Dispose();
        }
    }
}
