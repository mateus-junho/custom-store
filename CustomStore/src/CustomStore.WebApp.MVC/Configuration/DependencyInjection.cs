using CustomStore.Catalog.Application.Interfaces;
using CustomStore.Catalog.Application.Services;
using CustomStore.Catalog.Data.Contexts;
using CustomStore.Catalog.Data.Repositories;
using CustomStore.Catalog.Domain.Events;
using CustomStore.Catalog.Domain.Interfaces.Repository;
using CustomStore.Catalog.Domain.Interfaces.Services;
using CustomStore.Catalog.Domain.Services;
using CustomStore.Core.Communication;
using CustomStore.Sales.Application.Commands;
using CustomStore.Sales.Data.Contexts;
using CustomStore.Sales.Data.Repositories;
using CustomStore.Sales.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CustomStore.WebApp.MVC.Configuration
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // Domain Bus
            services.AddScoped<ICustomMediatrHandler, CustomMediatrHandler>();

            // Catalog
            services.AddScoped<CatalogContext>();

            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<IStockService, StockService>();

            services.AddScoped<IProductAppService, ProductAppService>();

            // Catalog - Event configuration
            services.AddScoped<INotificationHandler<ProductBelowStockMinEvent>, ProductEventHandler>();

            // Sales
            services.AddScoped<SalesContext>();

            services.AddScoped<IOrderRepository, OrderRepository>();

            services.AddScoped<IRequestHandler<AddOrderItemCommand, bool>, OrderCommandHandler>(); 
        }
    }
}
