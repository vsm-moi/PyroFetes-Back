namespace PyroFetes.DTO.QuotationProduct.Request;

public class AddQuotationProductDto
{
    public int Quantity { get; set; }
    public int QuotationId { get; set; }
    public int ProductId { get; set; }
}