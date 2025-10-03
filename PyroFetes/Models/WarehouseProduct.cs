using System.ComponentModel.DataAnnotations;

namespace PyroFetes.Models;

public class WarehouseProduct
{
    [Key] public int Quantity { get; set; }
    
    [Required] public int ProductId { get; set; }
    [Required] public Product? Product { get; set; }
    
    [Required] public int WarehouseId { get; set; }
    [Required] public Warehouse? Warehouse { get; set; }
}