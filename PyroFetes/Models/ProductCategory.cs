using System.ComponentModel.DataAnnotations;
using API.Models;

namespace PyroFetes.Models;

public class ProductCategory
{
    [Key] public int Id  { get; set; }
    [Required] public string? Label  { get; set; }
    
    [Required] public List<Product>? Products { get; set; }
}