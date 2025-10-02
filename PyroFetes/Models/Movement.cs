using System.ComponentModel.DataAnnotations;
using API.Class;

namespace API.Models;

public class Movement
{
    [Key] public int  Id  { get; set; }
    [Required] public DateTime Date  { get; set; }
    [Required] public DateTime Start {get; set;}
    [Required] public DateTime Arrival {get; set;}
    [Required] public int Quantity {get; set;}
    
    [Required] public int ProductId {get; set;}
    [Required] public Product Product {get; set;}
    
    [Required] public int? SourceWarehouseId {get; set;}
    [Required] public Warehouse SourceWarehouse {get; set;}
    
    [Required] public int? DestinationWarehouseId {get; set;}
    [Required] public Warehouse DestinationWarehouse {get; set;}
}