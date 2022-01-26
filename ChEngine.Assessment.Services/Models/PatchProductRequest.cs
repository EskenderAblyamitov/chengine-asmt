namespace ChEngine.Assessment.Services.Models;

public class PatchProductRequest
{
    public string? MerchantProductNo { get; set; }

    public object? Value { get; set; }

    public string? Path { get; set; }

    public PatchOperation Operation { get; set; }

    public string? From { get; set; }
}

public enum PatchOperation
{
    Add,
    Replace,
    Remove
}
