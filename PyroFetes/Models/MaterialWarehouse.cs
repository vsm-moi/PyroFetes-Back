using System.ComponentModel.DataAnnotations;

namespace PyroFetes.Models;

public class MaterialWarehouse
{
    [Required] public int MaterialId { get; set; }
    [Required] public int WarehouseId { get; set; }
    
    public Material? Material { get; set; }
    public Warehouse? Warehouse { get; set; }
}