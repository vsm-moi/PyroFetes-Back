using API.Class;

namespace API.Models;

public class Material
{
    public int Id {get; set;}
    public string Name {get; set;}
    public int Quantity {get; set;}
    
    public int WarehouseId {get; set;}
    public Warehouse Warehouse {get; set;}
}