
using CustomStore.Catalog.Application.DTOs;
using CustomStore.Catalog.Domain.Entities;
using CustomStore.Catalog.Domain.ValueObjects;
using System.Collections.Generic;
using System.Linq;

namespace CustomStore.Catalog.Application.Mappings
{
    internal static class ProductDtoMapping
    {
        internal static ProductDto BuildDto(this Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                CategoryId = product.CategoryId,
                Name = product.Name,
                Description = product.Description,
                Active = product.Active,
                Price = product.Price,
                Image = product.Image,
                Quantity = product.Quantity,
                Height = product.Dimensions.Height,
                Width = product.Dimensions.Width,
                Depth = product.Dimensions.Depth,
                Category = product.Category.BuildDto(),
            };
        }

        internal static IEnumerable<ProductDto> BuildDtoList(this IEnumerable<Product> products)
        {
            return products.Select(product => product.BuildDto());
        }

        internal static Product BuildDomainModel(this ProductDto productDto)
        {
            return new Product(
                productDto.CategoryId,
                productDto.Name,
                productDto.Description,
                productDto.Active,
                productDto.Price,
                productDto.Quantity,
                productDto.Image,
                new Dimensions(productDto.Height, productDto.Width, productDto.Depth));
        }
    }
}
