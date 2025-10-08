using System.ComponentModel.DataAnnotations;

namespace PyroFetes.Models;

public class ServiceProvider
{
    [Key] public int Id { get; set; } 
    [Required] public decimal Price { get; set; }
    
    //Relations
    [Required] public int ProviderTypeId { get; set; }
    public ProviderType? ProviderType { get; set; }
    
    public List<Contract>? Contracts { get; set; }
    public List<ContactServiceProvider>? ContactServiceProviders { get; set; }
}