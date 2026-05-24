using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PyroFetes.Models;

[PrimaryKey(nameof(MaterialId), nameof(WarehouseId))]
public class MaterialWarehouse
{
    [Required] public int MaterialId { get; set; }
    [Required] public int WarehouseId { get; set; }

    public Material? Material { get; set; }
    public Warehouse? Warehouse { get; set; }
}