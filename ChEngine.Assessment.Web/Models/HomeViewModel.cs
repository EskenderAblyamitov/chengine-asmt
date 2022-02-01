using ChEngine.Assessment.Services.DTO;

namespace ChEngine.Assessment.Web.Models;

public class HomeViewModel
{
    public HomeViewModel(BusinessLogicResultDto dto)
    {
        IsSetStockSuccess = dto.IsSetStockSuccess;
        if(dto.IsGetSoldProductsSuccess) SoldProducts = dto.SoldProducts;
        SetStockMessage = dto.SetStockMessage;
        ErrorMessage = dto.ErrorMessage;
    }

    public HomeViewModel(string errorMessage)
    {
        ErrorMessage = errorMessage;
    }

    public IEnumerable<SoldProductDto>? SoldProducts { get; set; } = new List<SoldProductDto>();

    public bool IsSetStockSuccess { get; set; }

    public string? SetStockMessage { get; set; }

    public string? ErrorMessage { get; set; }
}