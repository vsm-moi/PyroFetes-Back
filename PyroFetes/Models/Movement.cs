using API.Class;

namespace API.Models;

public class Movement
{
    public int  Id  { get; set; }
    public DateTime Date  { get; set; }
    public DateTime Start {get; set;}
    public DateTime Arrival {get; set;}
    public int Quantity {get; set;}
    
    public int ProductId {get; set;}
    public Product Product {get; set;}
    
    public int? sourceWarehouse {get; set;}
    public Warehouse SourceWarehouse {get; set;}
    
    public int? destinationWarehouse {get; set;}
    public Warehouse DestinationWarehouse {get; set;}
}