using ChEngine.Assessment.Services.Models;

namespace ChEngine.Assessment.Services.Contracts;

/// <summary>
/// Products API provider
/// </summary>
public interface IProductsApi
{
    /// <summary>
    /// Patch product
    /// </summary>
    /// <param name="merchantProductNo"></param>
    /// <param name="patchRequest"></param>
    /// <returns></returns>
    Task<PatchProductResult> PatchAsync(string merchantProductNo, PatchProductRequest patchRequest);
}
