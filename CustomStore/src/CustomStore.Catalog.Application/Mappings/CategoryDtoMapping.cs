
using CustomStore.Catalog.Application.DTOs;
using CustomStore.Catalog.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CustomStore.Catalog.Application.Mappings
{
    internal static class CategoryDtoMapping
    {
        internal static CategoryDto BuildDto(this Category category)
        {
            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                Code = category.Code,
            };
        }

        internal static IEnumerable<CategoryDto> BuildDtoList(this IEnumerable<Category> categories)
        {
            return categories.Select(category => category.BuildDto());
        }
    }
}
