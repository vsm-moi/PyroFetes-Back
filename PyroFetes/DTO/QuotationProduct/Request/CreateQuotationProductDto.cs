namespace PyroFetes.DTO.QuotationProduct.Request;

public class CreateQuotationProductDto
{
    public int Quantity { get; set; }
    
    public int QuotationId { get; set; }
    public string? QuotationMessage { get; set; }
    public string? QuotationConditionsSale { get; set; }
    
    public int ProductId { get; set; }
    public int ProductReferences { get; set; }
    public string? ProductName { get; set; }
    public decimal ProductDuration {get; set;} 
    public decimal ProductCaliber { get; set; }
    public int ProductApprovalNumber { get; set; }
    public decimal ProductWeight { get; set; }
    public decimal ProductNec { get; set; }
    public decimal ProductSellingPrice { get; set; }
    public string? ProductImage { get; set; }
    public string? ProductLink { get; set; }
    public int ProductMinimalQuantity { get; set; }
}