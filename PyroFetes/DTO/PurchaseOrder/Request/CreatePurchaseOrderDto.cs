using PyroFetes.DTO.PurchaseProduct.Request;

namespace PyroFetes.DTO.PurchaseOrder.Request;

public class CreatePurchaseOrderDto
{
    public string? PurchaseConditions { get; set; }
    public List<CreatePurchaseOrderProductDto>? Products { get; set; }
}
