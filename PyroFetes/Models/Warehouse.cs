using System.ComponentModel.DataAnnotations;
using API.Models;

namespace API.Class;

public class Warehouse
{
    [Key] public int Id {get; set;}
    [Required, MaxLength(100)] public string Name {get; set;}
    [Required] public int MaxWeight {get; set;}
    [Required] public int Current {get; set;}
    [Required] public int MinWeight {get; set;}
    [Required] public string Adress { get; set; }
    [Required] public int ZipCode { get; set; }
    [Required] public string City { get; set; }
    
    
    [Required] public List<Material> Materials {get; set;}
    
    
    [Required] public List<Movement> MovementsSource { get; set; }
    [Required] public List<Movement> MovementsDestination { get; set; }
}