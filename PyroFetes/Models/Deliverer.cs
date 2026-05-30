using System.ComponentModel.DataAnnotations;

namespace PyroFetes.Models;

public class Deliverer
{
    [Key] public int Id { get; set; }
    [Required, MaxLength(100)] public string? Transporter { get; set; }

    public List<DeliveryNote>? DeliveryNotes { get; set; }
}