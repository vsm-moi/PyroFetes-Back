using System.ComponentModel.DataAnnotations;

namespace PyroFetes.Models;

public class DeliveryNote
{
    [Key] public int Id { get; set; }
    [Required, MaxLength(100)] public string? TrackingNumber { get; set; }
    public int DelivererId { get; set; }
    public int SupplierId { get; set; }
    [Required] public DateOnly EstimateDeliveryDate { get; set; }
    [Required] public DateOnly ExpeditionDate { get; set; }
    public DateOnly? RealDeliveryDate { get; set; }

    public Deliverer? Deliverer { get; set; }
    public Supplier? Supplier { get; set; }
    public List<ProductDelivery>? ProductDeliveries { get; set; }
}