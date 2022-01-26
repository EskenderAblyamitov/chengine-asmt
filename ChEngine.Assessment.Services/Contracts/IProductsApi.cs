using ChEngine.Assessment.Services.Models;

namespace ChEngine.Assessment.Services.Contracts;

public interface IProductsApi
{
    Task<PatchProductResult> PatchAsync(string merchantProductNo, PatchProductRequest patchRequest);
}
