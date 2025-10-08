using System.ComponentModel.DataAnnotations;

namespace PyroFetes.Models;

public class SoundCategory
{
    [Key] public int Id { get; set; }
    [Required, MaxLength(100)] public string Name { get; set; } = null!;
    
    public List<Sound>? Sounds { get; set; }
}