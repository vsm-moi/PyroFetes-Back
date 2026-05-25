namespace PyroFetes.DTO.PurchaseProduct.Response;

public class GetPurchaseProductDto
{
    public int ProductId { get; set; }
    public string? ProductReference { get; set; }
    public string? ProductName { get; set; }
    public decimal ProductDuration { get; set; }
    public int ProductCaliber { get; set; }
    public string? ProductApprovalNumber { get; set; }
    public decimal ProductWeight { get; set; }
    public decimal ProductNec { get; set; }
    public string? ProductImage { get; set; }
    public string? ProductLink { get; set; }
    public int ProductMinimalQuantity { get; set; }
    public decimal ProductPrice { get; set; }
    
    public int PurchaseOrderId { get; set; }

    public int Quantity { get; set; }
}