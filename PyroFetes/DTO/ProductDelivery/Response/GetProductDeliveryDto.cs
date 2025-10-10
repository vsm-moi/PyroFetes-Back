namespace PyroFetes.DTO.ProductDelivery.Response;

public class GetProductDeliveryDto
{
    public int ProductId { get; set; }
    public int ProductReference { get; set; }
    public string? ProductName { get; set; }
    public decimal ProductDuration {get; set;} 
    public decimal ProductCaliber { get; set; }
    public int ProductApprovalNumber { get; set; }
    public decimal ProductWeight { get; set; }
    public decimal ProductNec { get; set; }
    public string? ProductImage { get; set; }
    public string? ProductLink { get; set; }
    public int ProductMinimalQuantity { get; set; }
    
    public int DeliveryNoteId { get; set; }
    public string? DeliveryNoteTrackingNumber { get; set; }
    public DateOnly DeliveryNoteEstimateDeliveryDate { get; set; }
    public DateOnly DeliveryNoteExpeditionDate { get; set; }
    public DateOnly? DeliveryNoteRealDeliveryDate { get; set; }
    
    public int DeliveryNoteDeliverId { get; set; }
    public string? DeliveryNoteDeliverTransporter { get; set; }
    
    
    public int Quantity { get; set; }
}