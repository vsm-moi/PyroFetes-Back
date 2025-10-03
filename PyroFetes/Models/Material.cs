using System.ComponentModel.DataAnnotations;

namespace PyroFetes.Models;

public class Material
{
    [Key] public int Id {get; set;}
    [Required, MaxLength(100)] public string? Name {get; set;}
    [Required] public int Quantity {get; set;}
    
    [Required] public int WarehouseId {get; set;}
    [Required] public Warehouse? Warehouse {get; set;}
}