namespace ChEngine.Assessment.Services.Models;

public class Order
{
    public int Id { get; set; }

    public IEnumerable<OrderItem>? Lines { get; set; }

    public decimal TotalInclVat { get; set; }
}

public class OrderItem
{
    public string? MerchantProductNo { get; set; }

    public string? Description { get; set; }

    public string? Gtin { get; set; }

    public int Quantity { get; set; }
}

public enum OrderStatus
{
    IN_PROGRESS
}
