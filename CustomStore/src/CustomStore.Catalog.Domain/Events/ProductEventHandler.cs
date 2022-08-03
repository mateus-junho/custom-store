
using CustomStore.Catalog.Domain.Interfaces.Repository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CustomStore.Catalog.Domain.Events
{
    public class ProductEventHandler : INotificationHandler<ProductBelowStockMinEvent>
    {
        private readonly IProductRepository productRepository;

        public ProductEventHandler(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task Handle(ProductBelowStockMinEvent notification, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetById(notification.AggregateId);

            //send email to get more products
        }
    }
}
