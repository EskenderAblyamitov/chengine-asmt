using ChEngine.Assessment.Services.DTO;

namespace ChEngine.Assessment.Services.Contracts;

/// <summary>
/// Service to work with orders
/// </summary>
public interface IOrderService
{
    /// <summary>
    /// Get Top Sold Products
    /// </summary>
    /// <param name="count"></param>
    /// <returns></returns>
    Task<IEnumerable<SoldProductDto>> GetTopSoldProducts(int count);
}
