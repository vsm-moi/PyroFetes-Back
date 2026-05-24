namespace PyroFetes.DTO.PurchaseProduct.Request;

public class CreatePurchaseProductDto
{
    public int Quantity { get; set; } 
    public int ProductId { get; set; }
    public int PurchaseOrderId { get; set; }
}