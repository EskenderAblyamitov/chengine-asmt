using ChEngine.Assessment.ApiClient.Contracts;
using ChEngine.Assessment.ApiClient.Models;
using ChEngine.Assessment.Services.Contracts;
using ChEngine.Assessment.Services.DTO;

namespace ChEngine.Assessment.Services;

/// <inheritdoc />
public class OrderService : IOrderService
{
    private readonly IOrdersApi _ordersApi;

    public OrderService(IOrdersApi ordersApi)
    {
        _ordersApi = ordersApi;
    }

    /// <inheritdoc />
    public async Task<IEnumerable<SoldProductDto>> GetTopSoldProducts(int count)
    {
        var inProgressOrders = await _ordersApi.GetOrdersByStatusAsync(OrderStatus.IN_PROGRESS);

        var topSoldProducts = inProgressOrders
            .SelectMany(x => x.Lines ?? new List<OrderItem>())
            .GroupBy(x => x.MerchantProductNo)
            .Select(g => new SoldProductDto
            {
                Name = g.Key,
                Gtin = g.First().Gtin,
                Quantity = g.Sum(x => x.Quantity),
                MerchantProductNo = g.First().MerchantProductNo
            })
            .OrderByDescending(x => x.Quantity)
            .Skip(0)
            .Take(count);

        return topSoldProducts;
    }
}