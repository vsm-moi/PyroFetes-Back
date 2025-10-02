using System.ComponentModel.DataAnnotations;

namespace PyroFetes.Models;

public class Sound
{
    [Key] public int Id { get; set; }

    [Required, MaxLength(120)]
    public string Name { get; set; } = null!;

    [MaxLength(60)]
    public string? Type { get; set; }

    [MaxLength(120)]
    public string? Artist { get; set; }

    [Range(0, int.MaxValue)]
    public int? Duration { get; set; }

    [MaxLength(40)]
    public string? Kind { get; set; }

    [MaxLength(40)]
    public string? Format { get; set; }

    public DateTime? CreationDate { get; set; }

    [Required]
    public int SoundCategoryId { get; set; }
    public SoundCategory? Category { get; set; }

    public ICollection<SoundTimecode> ShowPlacements { get; set; } = new List<SoundTimecode>();
}