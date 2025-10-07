using System.ComponentModel.DataAnnotations;

namespace PyroFetes.Models;

public class PurchaseOrder
{
    [Key] public int Id { get; set; }
    [Required, MaxLength(300)] public string? PurchaseConditions { get; set; }
    
    public List<PurchaseProduct>? PurchaseProducts { get; set; }
}