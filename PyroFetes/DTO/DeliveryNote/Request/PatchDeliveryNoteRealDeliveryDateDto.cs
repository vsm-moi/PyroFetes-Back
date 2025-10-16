namespace PyroFetes.DTO.DeliveryNote.Request;

public class PatchDeliveryNoteRealDeliveryDateDto
{
    public int Id { get; set; }
    public DateOnly RealDeliveryDate { get; set; }
}