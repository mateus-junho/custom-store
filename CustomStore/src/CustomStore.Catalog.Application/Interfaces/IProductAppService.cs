
using CustomStore.Catalog.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomStore.Catalog.Application.Interfaces
{
    public interface IProductAppService : IDisposable
    {
        Task<IEnumerable<ProductDto>> GetByCategory(int code);
        Task<ProductDto> GetById(Guid id);
        Task<IEnumerable<ProductDto>> GetAll();
        Task AddProduct(ProductDto productDto);
        Task UpdateProduct(ProductDto productDto);

        Task<IEnumerable<CategoryDto>> GetCategories();

        Task<ProductDto> AddStock(Guid id, int quantity);
        Task<ProductDto> DebitStock(Guid id, int quantity);
    }
}
