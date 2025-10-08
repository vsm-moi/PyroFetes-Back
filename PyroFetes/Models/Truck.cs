using System.ComponentModel.DataAnnotations;

namespace PyroFetes.Models;

public class Truck
{
    [Key] public int Id { get; set; }
    [Required, MaxLength(40)] public string Type { get; set; } = null!;
    [Required] public double? MaxExplosiveCapacity { get; set; }
    [Required, MaxLength(80)] public string? Sizes { get; set; }
    [Required, MaxLength(40)] public string? Status { get; set; }
    
    public List<ShowTruck>? ShowTrucks { get; set; }
}