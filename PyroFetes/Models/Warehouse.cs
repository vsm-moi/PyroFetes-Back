using System.ComponentModel.DataAnnotations;

namespace PyroFetes.Models;

public class Warehouse
{
    [Key] public int Id {get; set;}
    [Required, MaxLength(100)] public string? Name {get; set;}
    [Required] public int MaxWeight {get; set;}
    [Required] public int Current {get; set;}
    [Required] public int MinWeight {get; set;}
    [Required, MaxLength(100)] public string? Address { get; set; }
    [Required] public int ZipCode { get; set; }
    [Required, MaxLength(100)] public string? City { get; set; }
    
    public List<WarehouseProduct>? WarehouseProducts { get; set; }
    public List<Material>? Materials {get; set;}
    public List<Movement>? MovementsSource { get; set; }
    public List<Movement>? MovementsDestination { get; set; }
}