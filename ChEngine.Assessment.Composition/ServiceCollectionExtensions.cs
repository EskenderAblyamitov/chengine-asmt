using ChEngine.Assessment.ApiClient.API;
using ChEngine.Assessment.ApiClient.Contracts;
using ChEngine.Assessment.Services;
using ChEngine.Assessment.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace ChEngine.Assessment.Composition
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterTypes(this IServiceCollection services)
        {
            services
                .AddScoped<IOrdersApi, OrdersApi>()
                .AddScoped<IProductsApi, ProductsApi>()
                .AddScoped<IOrderService, OrderService>()
                .AddScoped<IProductService, ProductService>();

            return services;
        }
    }
}
