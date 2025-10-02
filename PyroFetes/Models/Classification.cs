using System.ComponentModel.DataAnnotations;
using API.Class;

namespace API.Models;

public class Classification
{
    [Key] public int Id  { get; set; }
    [Required] public string Label  { get; set; }
    
    [Required] public List<Product> Products { get; set; }
}