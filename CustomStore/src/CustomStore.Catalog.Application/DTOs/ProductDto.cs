using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CustomStore.Catalog.Application.DTOs
{
    public class ProductDto
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public Guid CategoryId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public bool Active { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public decimal Price { get; set; }

        public string Image { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "The field {0} should have a value of at least {1}")]
        [Required(ErrorMessage = "The field {0} is required")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public decimal Height { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public decimal Width { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public decimal Depth { get; set; }

        public CategoryDto Category { get; set; }
    }
}
