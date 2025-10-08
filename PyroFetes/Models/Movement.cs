using System.ComponentModel.DataAnnotations;

namespace PyroFetes.Models;

public class Movement
{
    [Key] public int  Id  { get; set; }
    [Required] public DateTime Date  { get; set; }
    [Required] public DateTime Start {get; set;}
    [Required] public DateTime Arrival {get; set;}
    [Required] public int Quantity {get; set;}
    
    public List<Product>? Products { get; set; }
  
    public int? SourceWarehouseId {get; set;}
    public Warehouse? SourceWarehouse {get; set;}
    public int? DestinationWarehouseId {get; set;}
    public Warehouse? DestinationWarehouse {get; set;}
}