namespace PyroFetes.DTO.QuotationProduct.Response;

public class GetQuotationProductDto
{
    public int Quantity { get; set; }
    
    public int ProductId { get; set; }
    public string? ProductReference { get; set; }
    public string? ProductName { get; set; }
    public decimal ProductDuration {get; set;} 
    public int ProductCaliber { get; set; }
    public string? ProductApprovalNumber { get; set; }
    public decimal ProductWeight { get; set; }
    public decimal ProductNec { get; set; }
    public string? ProductImage { get; set; }
    public string? ProductLink { get; set; }
    public int ProductMinimalQuantity { get; set; }
}