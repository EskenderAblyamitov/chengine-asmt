using ChEngine.Assessment.Services.DTO;

namespace ChEngine.Assessment.Services.Contracts;

public interface IOrderService
{
    Task<IEnumerable<SoldProductDto>> GetTopSoldProducts(int count);
}
