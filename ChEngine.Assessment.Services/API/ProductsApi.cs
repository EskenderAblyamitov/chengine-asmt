using ChEngine.Assessment.Services.Contracts;
using ChEngine.Assessment.Services.Models;
using RestSharp;

namespace ChEngine.Assessment.Services.API;

public class ProductsApi : BaseApi, IProductsApi
{
    private const string PATCH_URL = "/v2/products/{merchant_product_no}";

    public async Task<PatchProductResult> PatchAsync(string merchantProductNo, PatchProductRequest patchRequest)
    {
        var request = new RestRequest(PATCH_URL, Method.Patch);
        request.AddUrlSegment("merchant_product_no", merchantProductNo);

        var patchObj =
        new[] {
                new
                {
                    Value = patchRequest.Value,
                    Path = patchRequest.Path,
                    Op = patchRequest.Operation.ToString().ToLower()
                }
        };
        request.AddJsonBody(patchObj);

        var result = await base.ExecuteAsync<PatchProductResult>(request);

        if (!result.IsSuccessful)
        {
            throw new Exception($"Unable to patch product {merchantProductNo}'. Error msg: {result.Data?.Message}");
        }

        return result.Data;
    }
}