namespace PyroFetes.DTO.PurchaseProduct.Request;

public class PatchPurchaseProductQuantityDto
{
    public int ProductId { get; set; }
    public int PurchaseOrderId { get; set; }
    public int Quantity { get; set; }
}