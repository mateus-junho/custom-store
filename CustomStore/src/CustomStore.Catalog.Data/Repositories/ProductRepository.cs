using CustomStore.Catalog.Data.Contexts;
using CustomStore.Catalog.Domain.Entities;
using CustomStore.Catalog.Domain.Interfaces.Repository;
using CustomStore.Core.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomStore.Catalog.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly CatalogContext context;
        public IUnitOfWork UnitOfWork => context;

        public ProductRepository(CatalogContext context)
        {
            this.context = context;
        }

        public void Add(Product product)
        {
            context.Products.Add(product);
        }

        public void Add(Category category)
        {
            context.Categories.Add(category);
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await context.Products.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetByCategory(int code)
        {
            return await context.Products.AsNoTracking()
                .Include(p => p.Category)
                .Where(p => p.Category.Code == code)
                .ToListAsync();
        }

        public async Task<Product> GetById(Guid id)
        {
            return await context.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await context.Categories.AsNoTracking().ToListAsync();
        }

        public void Update(Product product)
        {
            context.Products.Update(product);
        }

        public void Update(Category category)
        {
            context.Categories.Update(category);
        }

        public void Dispose()
        {
            context?.Dispose();
        }
    }
}
