using CustomStore.Catalog.Application.DTOs;
using CustomStore.Catalog.Application.Interfaces;
using CustomStore.Catalog.Application.Mappings;
using CustomStore.Catalog.Domain.Interfaces.Repository;
using CustomStore.Catalog.Domain.Interfaces.Services;
using CustomStore.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomStore.Catalog.Application.Services
{
    public class ProductAppService : IProductAppService
    {
        private readonly IProductRepository productRepository;
        private readonly IStockService stockService;

        public ProductAppService(IProductRepository productRepository, IStockService stockService)
        {
            this.productRepository = productRepository;
            this.stockService = stockService;
        }

        public async Task AddProduct(ProductDto productDto)
        {
            var product = productDto.BuildDomainModel();
            productRepository.Add(product);

            await productRepository.UnitOfWork.Commit();
        }

        public async Task<IEnumerable<ProductDto>> GetAll()
        {
            var products = await productRepository.GetAll();
            return products.BuildDtoList();
        }

        public async Task<IEnumerable<ProductDto>> GetByCategory(int code)
        {
            var products = await productRepository.GetByCategory(code);
            return products.BuildDtoList();
        }

        public async Task<ProductDto> GetById(Guid id)
        {
            var product = await productRepository.GetById(id);
            return product.BuildDto();
        }

        public async Task<IEnumerable<CategoryDto>> GetCategories()
        {
            var categories = await productRepository.GetCategories();
            return categories.BuildDtoList();
        }

        public async Task UpdateProduct(ProductDto productDto)
        {
            var product = productDto.BuildDomainModel();
            productRepository.Update(product);

            await productRepository.UnitOfWork.Commit();
        }

        public async Task<ProductDto> AddStock(Guid id, int quantity)
        {
            if (!stockService.AddStock(id, quantity).Result)
            {
                throw new DomainException("Fail to debit stock");
            }

            var product = await productRepository.GetById(id);
            return product.BuildDto();
        }

        public async Task<ProductDto> DebitStock(Guid id, int quantity)
        {
            if(!stockService.DebitStock(id, quantity).Result)
            {
                throw new DomainException("Fail to debit stock");
            }

            var product = await productRepository.GetById(id);
            return product.BuildDto();
        }

        public void Dispose()
        {
            productRepository?.Dispose();
            stockService?.Dispose();
        }
    }
}
