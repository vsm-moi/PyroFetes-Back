using System.ComponentModel.DataAnnotations;

namespace PyroFetes.Models;

public class Truck
{
    [Key] public int Id { get; set; }

    [Required, MaxLength(40)]
    public string Type { get; set; } = null!;

    [Range(0, double.MaxValue)]
    public double? MaxExplosiveCapacity { get; set; }

    [MaxLength(80)]
    public string? Sizes { get; set; }

    [MaxLength(40)]
    public string? Statut { get; set; }

    [Required]
    public int ShowId { get; set; }
    public Show? Show { get; set; }
}