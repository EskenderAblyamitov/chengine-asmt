using ChEngine.Assessment.ApiClient.Contracts;
using ChEngine.Assessment.ApiClient.Models;
using ChEngine.Assessment.Services.Contracts;
using ChEngine.Assessment.Services.Exceptions;

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

        try
        {
            await _productsApi.PatchAsync(merchantProductNo, patchRequest);
        }
        catch (Exception ex)
        {
            throw new SetProductStockException(ex);
        }        
    }
}