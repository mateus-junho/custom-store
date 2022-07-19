using CustomStore.Catalog.Domain.Constants;
using CustomStore.Catalog.Domain.Entities;
using CustomStore.Catalog.Domain.ValueObjects;
using CustomStore.Core.DomainObjects;
using System;
using Xunit;

namespace CustomStore.Catalog.Domain.Tests
{
    public class ProductTests
    {
        [Fact]
        public void Product_Validate()
        {
            var ex = Assert.Throws<DomainException>(() =>
                new Product(Guid.NewGuid(), string.Empty, "Description", false, 100, 10, "Image", new Dimensions(1, 1, 1))
            );
            Assert.Equal(ExceptionMessages.NameValidationMessage, ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Product(Guid.NewGuid(), "Name", string.Empty, false, 100, 10, "Image", new Dimensions(1, 1, 1))
            );
            Assert.Equal(ExceptionMessages.DescriptionValidationMessage, ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Product(Guid.NewGuid(), "Name", "Description", false, 0, 10, "Image", new Dimensions(1, 1, 1))
            );
            Assert.Equal(ExceptionMessages.PriceValidationMessage, ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Product(Guid.NewGuid(), "Name", "Description", false, 100, 0, "Image", new Dimensions(1, 1, 1))
            );
            Assert.Equal(ExceptionMessages.QuantityValidationMessage, ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Product(Guid.Empty, "Name", "Descricao", false, 100, 10, "Image", new Dimensions(1, 1, 1))
            );
            Assert.Equal(ExceptionMessages.CategoryIdValidationMessage, ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Product(Guid.NewGuid(), "Name", "Descricao", false, 100, 10, string.Empty, new Dimensions(1, 1, 1))
            );
            Assert.Equal(ExceptionMessages.ImageValidationMessage, ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Product(Guid.NewGuid(), "Name", "Descricao", false, 100, 10, "Image", new Dimensions(0, 1, 1))
            );
            Assert.Equal(ExceptionMessages.HeightValidationMessage, ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Product(Guid.NewGuid(), "Name", "Descricao", false, 100, 10, "Image", new Dimensions(1, 0, 1))
            );
            Assert.Equal(ExceptionMessages.WidthValidationMessage, ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Product(Guid.NewGuid(), "Name", "Descricao", false, 100, 10, "Image", new Dimensions(1, 1, 0))
            );
            Assert.Equal(ExceptionMessages.DepthValidationMessage, ex.Message);
        }
    }
}
