using CustomStore.Catalog.Domain.Constants;
using CustomStore.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStore.Catalog.Domain.ValueObjects
{
    public class Dimensions
    {
        public decimal Height { get; private set; }

        public decimal Width { get; private set; }

        public decimal Depth { get; private set; }

        public Dimensions(decimal height, decimal width, decimal depth)
        {
            Height = height;
            Width = width;
            Depth = depth;

            Validate();
        }

        public void Validate()
        {
            AssertionConcern.ValidateLessOrEqualsThan(Height, 0, ExceptionMessages.HeightValidationMessage);
            AssertionConcern.ValidateLessOrEqualsThan(Width, 0, ExceptionMessages.WidthValidationMessage);
            AssertionConcern.ValidateLessOrEqualsThan(Depth, 0, ExceptionMessages.DepthValidationMessage);
        }
    }
}
