namespace PyroFetes.DTO.WareHouseProduct.Request;

public class PatchWareHouseProductQuantityDto
{
    public int WareHouseId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}