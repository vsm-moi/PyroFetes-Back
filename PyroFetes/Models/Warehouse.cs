using API.Models;

namespace API.Class;

public class Warehouse
{
    public int Id {get; set;}
    public string Name {get; set;}
    public int MaxWeight {get; set;}
    public int Current {get; set;}
    public int MinWeight {get; set;}
    public string Adress { get; set; }
    public int ZipCode { get; set; }
    public string City { get; set; }
    
    
    public List<Material> Materials {get; set;}
    
    
    public List<Movement> MovementsSource { get; set; }
    public List<Movement> MovementsDestination { get; set; }
}