namespace PyroFetes.DTO.ProductDelivery.Request;

public class UpdateProductDeliveryDto
{
    public int Quantity { get; set; }
    public int ProductId { get; set; }
    public int DeliveryNoteId { get; set; }
}