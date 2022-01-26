namespace ChEngine.Assessment.Services.Contracts;

/// <summary>
/// Service to work with products
/// </summary>
public interface IProductService
{
    /// <summary>
    /// Set the stock of a product by MerchantProductNo
    /// </summary>
    /// <param name="merchantProductNo"></param>
    /// <param name="stock"></param>
    /// <returns></returns>
    Task SetStockAsync(string merchantProductNo, int stock);
}