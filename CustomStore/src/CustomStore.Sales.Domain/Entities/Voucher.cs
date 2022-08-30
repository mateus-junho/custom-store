
using CustomStore.Core.DomainObjects;
using CustomStore.Sales.Domain.Constants;
using System;
using System.Collections.Generic;

namespace CustomStore.Sales.Domain.Entities
{
    public class Voucher : Entity
    {
        public string Code { get; private set; }

        public decimal? Percentage { get; private set; }

        public decimal? DiscountValue { get; private set; }

        public int Quantity { get; private set; }

        public VoucherDiscountType VoucherDiscountType { get; private set; }

        public DateTime RegisterDate { get; private set; }

        public DateTime? UtilizationDate { get; private set; }

        public DateTime ValidDate { get; private set; }

        public bool Active { get; private set; }

        public bool Used { get; private set; }

        public IEnumerable<Order> Orders { get; set; }
    }
}
