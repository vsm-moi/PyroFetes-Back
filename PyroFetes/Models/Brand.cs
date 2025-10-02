using System.ComponentModel.DataAnnotations;
using API.Class;

namespace API.Models;

public class Brand
{
    [Key] public int Id  { get; set; }
    [Required, MaxLength(100)] public string Name  { get; set; }
    
    [Required] public int ProductId { get; set; }
    [Required] public Product Product { get; set; }
}