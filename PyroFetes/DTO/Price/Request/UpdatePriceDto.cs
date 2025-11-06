namespace PyroFetes.DTO.Price.Request;

public class UpdatePriceDto
{
    public int Id { get; set; }
    public decimal SellingPrice { get; set; }
    
    public int SupplierId { get; set; }
    public string? SupplierName { get; set; }
    public string? SupplierEmail { get; set; }
    public string? SupplierPhone { get; set; }
    public string? SupplierAddress { get; set; }
    public int SupplierZipCode { get; set; }
    public string? SupplierCity { get; set; }
    public int SupplierDeliveryDelay { get; set; }
    
    public int ProductId { get; set; }
    public string? ProductReferences { get; set; }
    public string? ProductName { get; set; }
    public decimal ProductDuration {get; set;} 
    public decimal ProductCaliber { get; set; }
    public int ProductApprovalNumber { get; set; }
    public decimal ProductWeight { get; set; }
    public decimal ProductNec { get; set; }
    public string? ProductImage { get; set; }
    public string? ProductLink { get; set; }
    public int ProductMinimalQuantity { get; set; }
}