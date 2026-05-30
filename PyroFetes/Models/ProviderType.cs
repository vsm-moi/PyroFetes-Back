using System.ComponentModel.DataAnnotations;

namespace PyroFetes.Models;

public class ProviderType
{
    [Key] public int Id { get; set; }
    [Required, MaxLength(100)] public string? Label { get; set; }

    public List<ServiceProvider>? ServiceProviders { get; set; }
}