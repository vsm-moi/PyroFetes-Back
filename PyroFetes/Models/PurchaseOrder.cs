using System.ComponentModel.DataAnnotations;

namespace PyroFetes.Models;

public class PurchaseOrder
{
    [Key] public int Id { get; set; }
    [Required, MaxLength(300)] public string? PurchaseConditions { get; set; }
    
    [Required] public int SupplierId { get; set; }
    public Supplier? Supplier { get; set; }
    public List<PurchaseProduct>? PurchaseProducts { get; set; }
}