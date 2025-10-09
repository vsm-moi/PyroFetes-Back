namespace PyroFetes.DTO.PurchaseProduct.Request;

public class PatchPurchaseProductQuantityDto
{
    public int Id { get; set; }
    public int Quantity { get; set; } 
    
    public int ProductId { get; set; }
    
    public int PurchaseOrderId { get; set; }
}