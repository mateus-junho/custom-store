﻿using CustomStore.Catalog.Domain.Entities;
using CustomStore.Core.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomStore.Catalog.Domain.Interfaces.Repository
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetAll();

        Task<Product> GetById(Guid id);

        Task<IEnumerable<Product>> GetByCategory(int code);

        Task<IEnumerable<Category>> GetCategories();

        void Add(Product product);

        void Update(Product product);

        void Add(Category category);

        void Update(Category category);
    }
}
