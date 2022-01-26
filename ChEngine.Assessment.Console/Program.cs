using ChEngine.Assessment.Services;
using ChEngine.Assessment.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new ServiceCollection()
                .AddScoped<IOrderService, OrderService>()
                .BuildServiceProvider();

var orderService = serviceProvider.GetService<IOrderService>();

if (orderService == null)
{
    Console.WriteLine($"Unable to get service of type {typeof(IOrderService).Name}");
}
else
{
    var topSoldProducts = await orderService.GetTopSoldProducts(5);
    
    if(topSoldProducts?.Any() == true)
    {
        foreach (var product in topSoldProducts)
        {
            Console.WriteLine(product.ToString());
        }
    }
}