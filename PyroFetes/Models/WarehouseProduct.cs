using System.ComponentModel.DataAnnotations;
using API.Class;

namespace API.Models;

public class WarehouseProduct
{
    public int Quantity { get; set; }
    
    public int ProductId { get; set; }
    [Required] public Product Product { get; set; }
    
    public int WarehouseId { get; set; }
    [Required] public Warehouse Warehouse { get; set; }
}