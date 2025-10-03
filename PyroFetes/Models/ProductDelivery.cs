using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PyroFetes.Models;

[PrimaryKey(nameof(ProductId), nameof(DeliveryNoteId))]
public class ProductDelivery
{
    [Required] public int ProductId { get; set; }
    [Required] public int DeliveryNoteId { get; set; }
    [Required] public int Quantity { get; set; }
    
    public Product? Product { get; set; }
    public DeliveryNote? DeliveryNote { get; set; }
}
    