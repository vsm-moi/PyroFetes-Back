using System.ComponentModel.DataAnnotations;

namespace PyroFetes.Models;

public class Effect
{
    [Key] public int Id { get; set; }
    [Required, MaxLength(200)] public string? Label { get; set; }

    public List<ProductEffect>? ProductEffects { get; set; }
}