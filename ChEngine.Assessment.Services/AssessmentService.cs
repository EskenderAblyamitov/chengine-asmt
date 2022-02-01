using ChEngine.Assessment.Services.Contracts;
using ChEngine.Assessment.Services.DTO;
using ChEngine.Assessment.Services.Exceptions;

namespace ChEngine.Assessment.Services;

public class AssessmentService : IAssessmentService
{
    private readonly IOrderService _orderService;
    private readonly IProductService _productService;

    public AssessmentService(IOrderService orderService, IProductService productService)
    {
        _orderService = orderService;
        _productService = productService;
    }

    public async Task<BusinessLogicResultDto> DoBusinessLogic()
    {
        var result = new BusinessLogicResultDto();

        try
        {
            var topSoldProducts = await _orderService.GetTopSoldProducts(5);

            if (topSoldProducts?.Any() == true)
            {
                result.IsGetSoldProductsSuccess = true;
                result.SoldProducts = topSoldProducts;                

                var merchantProductNo = topSoldProducts.First().MerchantProductNo;
                var newStock = 25;
                await _productService.SetStockAsync(merchantProductNo, newStock);

                result.IsSetStockSuccess = true;
                result.SetStockMessage = $"The stock has been set to {newStock} for product {merchantProductNo}";
            }
            else
            {
                result.ErrorMessage = $"No any sold products have been received from the API";
            }
        }
        catch(GetTopSoldProductsException ex)
        {
            result.ErrorMessage = $"Unable to get top sold products. Error: {ex.Message}";
        }
        catch(SetProductStockException ex)
        {
            result.ErrorMessage = $"Unable to set stock for product. Error: {ex.Message}";
        }
        catch (Exception ex)
        {
            result.ErrorMessage = $"Unable to run business logic. Error: {ex.Message}";
        }

        return result;
    }
}