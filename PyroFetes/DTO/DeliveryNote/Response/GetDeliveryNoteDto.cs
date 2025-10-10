using PyroFetes.DTO.ProductDelivery.Response;

namespace PyroFetes.DTO.DeliveryNote.Response;

public class GetDeliveryNoteDto
{
    public int Id { get; set; }
    public string? TrackingNumber { get; set; }
    public DateOnly EstimateDeliveryDate { get; set; }
    public DateOnly ExpeditionDate { get; set; }
    public DateOnly? RealDeliveryDate { get; set; }
    
    public int DeliverId { get; set; }
    public string? DeliverTransporter { get; set; }
    
    public List<GetProductDeliveryDto>  Products { get; set; }
}