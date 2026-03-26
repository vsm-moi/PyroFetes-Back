namespace PyroFetes.DTO.Price.Response;

public class GetPriceDto
{
    public int Id { get; set; }
    public decimal SellingPrice { get; set; }
    
    public int SupplierId { get; set; }
    public string? SupplierName { get; set; }
    public string? SupplierEmail { get; set; }
    public string? SupplierPhone { get; set; }
    public string? SupplierAddress { get; set; }
    public string? SupplierZipCode { get; set; }
    public string? SupplierCity { get; set; }
    public int SupplierDeliveryDelay { get; set; }
    
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