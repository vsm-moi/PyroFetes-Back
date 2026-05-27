namespace PyroFetes.DTO.DeliveryNote.Request;

public class CreateDeliveryNoteDto
{
    public string? TrackingNumber { get; set; }

    public int DelivererId { get; set; }
    public int SupplierId { get; set; }

    public Dictionary<int, int>? ProductQuantities { get; set; }
}