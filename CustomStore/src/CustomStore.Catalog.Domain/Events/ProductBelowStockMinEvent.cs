using CustomStore.Core.Messages.DomainEvents;
using System;

namespace CustomStore.Catalog.Domain.Events
{
    public class ProductBelowStockMinEvent : DomainEvent
    {
        public int RemainingQuantity { get; private set; }

        public ProductBelowStockMinEvent(Guid aggregateId, int remainingQuantity) : base(aggregateId)
        {
            RemainingQuantity = remainingQuantity;
        }
    }
}
