using PyroFetes.DTO.PurchaseProduct.Response;

namespace PyroFetes.DTO.PurchaseOrder.Response;

public class GetPurchaseOrderDto
{
    public int Id { get; set; }
    public string? PurchaseConditions { get; set; }
    public int SupplierId { get; set; }
    public string? SupplierName { get; set; }
    public List<GetPurchaseProductDto>? Products { get; set; }
}