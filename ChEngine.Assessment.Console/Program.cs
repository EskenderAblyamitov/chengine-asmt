using ChEngine.Assessment.Services;
using ChEngine.Assessment.Services.API;
using ChEngine.Assessment.Services.Contracts;
using ChEngine.Assessment.Services.DTO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

var serviceProvider = new ServiceCollection()
                .AddScoped<IOrdersApi, OrdersApi>()
                .AddScoped<IProductsApi, ProductsApi>()
                .AddScoped<IOrderService, OrderService>()
                .AddScoped<IProductService, ProductService>()
                .AddSingleton<IConfiguration>(configBuilder)
                .BuildServiceProvider();

var orderService = serviceProvider.GetService<IOrderService>();
var productService = serviceProvider.GetService<IProductService>();

if (orderService != null)
{
    IEnumerable<SoldProductDto>? topSoldProducts = null;

    try
    {
        topSoldProducts = await orderService.GetTopSoldProducts(5);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: Unable to get top sold products. ErrMsg: {ex.Message}");
    }

    if (topSoldProducts?.Any() == true)
    {
        foreach (var product in topSoldProducts)
        {
            Console.WriteLine(product.ToString());
        }

        if (productService != null)
        {
            var merchantProductNo = topSoldProducts.First().MerchantProductNo;
            var newStock = 25;

            try
            {
                await productService.SetStockAsync(merchantProductNo, newStock);

                Console.WriteLine();
                Console.WriteLine($"The stock has been set to {newStock} for product {merchantProductNo}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: Unable to set stock for {merchantProductNo}. ErrMsg: {ex.Message}");
            }
        }
    }
}

Console.WriteLine("Press any key to exit...");
Console.ReadKey();