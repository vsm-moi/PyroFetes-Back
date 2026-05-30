namespace PyroFetes.DTO.Price.Request;

public class CreatePriceDto
{
    public decimal SellingPrice { get; set; }
    public int? SupplierId { get; set; }
    public int ProductId { get; set; }
}