using ChEngine.Assessment.Services.Contracts;
using ChEngine.Assessment.Services.DTO;

namespace ChEngine.Assessment.Services;

public class OrderService : IOrderService
{
    public async Task<IEnumerable<SoldProductDto>> GetTopSoldProducts(int count)
    {
        return new List<SoldProductDto>
        {
            new SoldProductDto{ Name = "prod 1", Gtin = "111111", Quantity = 1 },
            new SoldProductDto{ Name = "prod 2", Gtin = "2222222", Quantity = 2 },
            new SoldProductDto{ Name = "prod 3", Gtin = "3333333", Quantity = 3 },
            new SoldProductDto{ Name = "prod 4", Gtin = "4444444", Quantity = 4 },
            new SoldProductDto{ Name = "prod 5", Gtin = "555555", Quantity = 5 },
        };
    }
}