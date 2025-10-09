namespace PyroFetes.DTO.PurchaseProduct.Request;

public class UpdatePurchaseProductDto
{
    public int Id { get; set; }
    public int Quantity { get; set; } 
    
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
    
    
    public int PurchaseOrderId { get; set; }
    public string? PurchaseOrderPurchaseConditions { get; set; }
}