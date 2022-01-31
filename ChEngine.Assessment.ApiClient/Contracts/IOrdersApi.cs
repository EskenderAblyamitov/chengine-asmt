using ChEngine.Assessment.ApiClient.Models;

namespace ChEngine.Assessment.ApiClient.Contracts;

/// <summary>
/// Orders API provider
/// </summary>
public interface IOrdersApi
{
    /// <summary>
    /// Get Orders By Status
    /// </summary>
    /// <param name="status"></param>
    /// <returns></returns>
    Task<IEnumerable<Order>> GetOrdersByStatusAsync(OrderStatus status);
}
