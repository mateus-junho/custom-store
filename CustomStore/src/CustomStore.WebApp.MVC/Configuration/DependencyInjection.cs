using CustomStore.Catalog.Application.Interfaces;
using CustomStore.Catalog.Application.Services;
using CustomStore.Catalog.Data.Contexts;
using CustomStore.Catalog.Data.Repositories;
using CustomStore.Catalog.Domain.Interfaces.Repository;
using CustomStore.Catalog.Domain.Interfaces.Services;
using CustomStore.Catalog.Domain.Services;
using CustomStore.Core.Bus;
using Microsoft.Extensions.DependencyInjection;

namespace CustomStore.WebApp.MVC.Configuration
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // Domain Bus
            services.AddScoped<IMediatrHandler, MediatrHandler>();

            // Catalog
            services.AddScoped<CatalogContext>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<IStockService, StockService>();

            services.AddScoped<IProductAppService, ProductAppService>();
        }
    }
}
