namespace PyroFetes.DTO.QuotationProduct.Request;

public class PatchQuotationProductQuantityDto
{
    public int ProductId { get; set; }
    public int QuotationId { get; set; }
    public int Quantity { get; set; }
}