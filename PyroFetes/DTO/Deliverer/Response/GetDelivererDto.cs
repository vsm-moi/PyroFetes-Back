using PyroFetes.DTO.DeliveryNote.Response;

namespace PyroFetes.DTO.Deliverer.Response;

public class GetDelivererDto
{
    public int Id { get; set; }
    public string? Transporter { get; set; }
    
    public List<GetDeliveryNoteDto>? DeliveryNotes { get; set; }
}