using ChEngine.Assessment.Services.DTO;

namespace ChEngine.Assessment.Web.Models;

public class HomeViewModel
{
    public bool IsSuccess { get; set; }

    public IEnumerable<SoldProductDto> SoldProducts { get; set; } = new List<SoldProductDto>();

    public string? UpdateStockMessage { get; set; }

    public string? ErrorMessage { get; set; }
}