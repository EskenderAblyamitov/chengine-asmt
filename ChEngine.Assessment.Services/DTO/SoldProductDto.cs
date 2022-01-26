namespace ChEngine.Assessment.Services.DTO;

public class SoldProductDto
{
    public string? Name { get; set; }

    public string? Gtin { get; set; }

    public int Quantity { get; set; }

    public override string ToString()
    {
        return $"{Name}\t{Gtin}\t{Quantity}";
    }
}
