using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PyroFetes.Models;

[PrimaryKey(nameof(ProductId), nameof(WarehouseId))]
public class WarehouseProduct
{
    [Required] public int ProductId { get; set; }
    public Product? Product { get; set; }
    [Required] public int WarehouseId { get; set; }
    public Warehouse? Warehouse { get; set; }
    
    [Required] public int Quantity { get; set; }
}