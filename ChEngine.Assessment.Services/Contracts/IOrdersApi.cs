using ChEngine.Assessment.Services.Models;

namespace ChEngine.Assessment.Services.Contracts;

public interface IOrdersApi
{
    Task<IEnumerable<Order>> GetOrdersByStatusAsync(OrderStatus status);
}
