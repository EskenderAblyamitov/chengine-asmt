namespace ChEngine.Assessment.Services.Contracts;

public interface IProductService
{
    Task SetStockAsync(string merchantProductNo, int stock);
}