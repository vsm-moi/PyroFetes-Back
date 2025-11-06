namespace PyroFetes.DTO.Price.Request;

public class PatchPriceSellingPriceDto
{
    public int ProductId { get; set; }
    public int SupplierId { get; set; }
    public decimal SellingPrice { get; set; }
}