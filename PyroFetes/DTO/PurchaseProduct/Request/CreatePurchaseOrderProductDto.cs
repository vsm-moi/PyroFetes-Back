namespace PyroFetes.DTO.PurchaseProduct.Request;

// Pour ajouter les produits lors de la création
public class CreatePurchaseOrderProductDto
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}