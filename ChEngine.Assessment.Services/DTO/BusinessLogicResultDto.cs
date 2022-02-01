namespace ChEngine.Assessment.Services.DTO;

public class BusinessLogicResultDto
{
    public bool IsGetSoldProductsSuccess { get; set; }

    public bool IsSetStockSuccess { get; set; }

    public IEnumerable<SoldProductDto>? SoldProducts { get; set; } = new List<SoldProductDto>();

    public string? SetStockMessage { get; set; }

    public string? ErrorMessage { get; set; }
}
