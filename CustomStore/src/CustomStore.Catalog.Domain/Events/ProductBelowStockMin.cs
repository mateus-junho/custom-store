using CustomStore.Core.DomainObjects;
using System;

namespace CustomStore.Catalog.Domain.Events
{
    public class ProductBelowStockMin : DomainEvent
    {
        public int RemainingQuantity { get; private set; }

        public ProductBelowStockMin(Guid aggregateId, int remainingQuantity) : base(aggregateId)
        {
            RemainingQuantity = remainingQuantity;
        }
    }
}
