using System.ComponentModel.DataAnnotations;

namespace PyroFetes.Models;

public class Provider
{
    [Key] public int Id { get; set; } 
    [Required] public decimal Price { get; set; }
    
    //Relations
    
    public int ProviderId { get; set; }
    public ProviderType? ProviderType { get; set; }
}