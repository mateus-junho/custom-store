using CustomStore.Catalog.Domain.ValueObjects;
using CustomStore.Core.DomainObjects;
using System;

namespace CustomStore.Catalog.Domain.Entities
{
    public class Product : Entity, IAggregateRoot
    {
        public Guid CategoryId { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public bool Active { get; private set; }

        public decimal Price { get; private set; }

        public DateTime RegisterDate { get; private set; }

        public string Image { get; private set; }

        public int Quantity { get; private set; }

        public Dimensions Dimensions { get; private set; }

        public Category Category { get; private set; }

        public Product(Guid categoryId, string name, string description, bool active, decimal price, string image, Dimensions dimensions)
        {
            CategoryId = categoryId;
            Name = name;
            Description = description;
            Active = active;
            Price = price;
            Image = image;
            Dimensions = dimensions;

            Validate();
        }

        protected Product() { }

        public void Activate() => Active = true;

        public void Deactivate() => Active = false;

        public void SetCategory(Category category)
        {
            Category = category;
            CategoryId = category.Id;
        }

        public void SetDescription(string description)
        {
            Description = description;
        }

        public void TakeQuantity(int quantity)
        {
            if(quantity < 0)
            {
                quantity *= -1;
            }

            if(!HasQuantityAvailable(quantity))
            {
                throw new DomainException("Unavailable quantity");
            }

            Quantity -= quantity;
        }

        public void AddQuantity(int quantity)
        {
            Quantity += quantity;
        }

        public bool HasQuantityAvailable(int quantity)
        {
            return Quantity >= quantity;
        }

        public void SetDimensions(Dimensions dimensions)
        {
            Dimensions = dimensions;
        }

        public void Validate()
        {
            AssertionConcern.ValidateEmpty(Name, "Name cannot be empty");
            AssertionConcern.ValidateEmpty(Description, "Description cannot be empty");
            AssertionConcern.ValidateDifferent(CategoryId, Guid.Empty, "Category Id cannot be empty");
            AssertionConcern.ValidateLessOrEqualsThan(Price, 0, "Price cannot be less or equals than 0");
            AssertionConcern.ValidateEmpty(Image, "Image cannot be empty");
        }
    }
}
