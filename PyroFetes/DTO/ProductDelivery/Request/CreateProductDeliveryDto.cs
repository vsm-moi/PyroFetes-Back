namespace PyroFetes.DTO.ProductDelivery.Request;

public class CreateProductDeliveryDto
{
    public int ProductId { get; set; }
    public int DeliveryNoteId { get; set; }
    public int Quantity { get; set; }
}