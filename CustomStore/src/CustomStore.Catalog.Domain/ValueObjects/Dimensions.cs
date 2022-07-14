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
            AssertionConcern.ValidateLessOrEqualsThan(Height, 0, "Height should be greater than 0");
            AssertionConcern.ValidateLessOrEqualsThan(Width, 0, "Height should be greater than 0");
            AssertionConcern.ValidateLessOrEqualsThan(Depth, 0, "Height should be greater than 0");
        }
    }
}
