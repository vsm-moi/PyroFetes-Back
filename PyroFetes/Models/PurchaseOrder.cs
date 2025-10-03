using System.ComponentModel.DataAnnotations;

namespace PyroFetes.Models;

public class PurchaseOrder
{
    [Key] public int Id { get; set; }
    [Required] public string? PurchaseConditions { get; set; }
}