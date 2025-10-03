using System.ComponentModel.DataAnnotations;

namespace PyroFetes.Models;

public class SoundCategory
{
    [Key] public int Id { get; set; }
    [Required, MaxLength(60)] public string Name { get; set; } = null!;
    public ICollection<Sound>? Sounds { get; set; }
}