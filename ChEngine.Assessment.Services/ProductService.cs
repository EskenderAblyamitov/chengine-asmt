using ChEngine.Assessment.Services.Contracts;
using ChEngine.Assessment.Services.Models;

namespace ChEngine.Assessment.Services;

/// <inheritdoc />
public class ProductService : IProductService
{
    private readonly IProductsApi _productsApi;

    public ProductService(IProductsApi productsApi)
    {
        _productsApi = productsApi;
    }

    /// <inheritdoc />
    public async Task SetStockAsync(string merchantProductNo, int stock)
    {
        var patchRequest = new PatchProductRequest
        {
            Path = "Stock",
            Value = stock,
            Operation = PatchOperation.Replace
        };

        await _productsApi.PatchAsync(merchantProductNo, patchRequest);
    }
}