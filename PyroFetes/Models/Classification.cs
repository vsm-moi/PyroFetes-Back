using API.Class;

namespace API.Models;

public class Classification
{
    public int Id  { get; set; }
    public string Label  { get; set; }
    
    public List<Product> Products { get; set; }
}