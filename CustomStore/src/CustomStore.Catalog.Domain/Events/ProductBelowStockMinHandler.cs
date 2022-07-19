
using CustomStore.Catalog.Domain.Interfaces.Repository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CustomStore.Catalog.Domain.Events
{
    public class ProductBelowStockMinHandler : INotificationHandler<ProductBelowStockMin>
    {
        private readonly IProductRepository productRepository;

        public ProductBelowStockMinHandler(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task Handle(ProductBelowStockMin notification, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetById(notification.AggregateId);

            //send email to get more products
        }
    }
}
