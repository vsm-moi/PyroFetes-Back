using System.ComponentModel.DataAnnotations;

namespace PyroFetes.Models;

public class Sound
{
    [Key] public int Id { get; set; }
    [Required, MaxLength(120)] public string Name { get; set; } = null!;
    [Required, MaxLength(60)] public string? Type { get; set; }
    [Required, MaxLength(120)] public string? Artist { get; set; }
    [Required, Range(0, int.MaxValue)] public int? Duration { get; set; }
    [Required, MaxLength(40)] public string? Kind { get; set; }
    [Required, MaxLength(40)] public string? Format { get; set; }
    public DateTime? CreationDate { get; set; }
    [Required] public int SoundCategoryId { get; set; }
    public SoundCategory? Category { get; set; }
    public ICollection<SoundTimecode>? ShowPlacements { get; set; }
}