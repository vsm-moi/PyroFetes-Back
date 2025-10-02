using System.ComponentModel.DataAnnotations;

namespace PyroFetes.Models;

public class SoundTimecode
{
    [Key] public int Id { get; set; }

    [Required]
    public int ShowId { get; set; }
    public Show? Show { get; set; }

    [Required]
    public int SoundId { get; set; }
    public Sound? Sound { get; set; }

    [Required, Range(0, int.MaxValue)]
    public int Start { get; set; }

    [Required, Range(0, int.MaxValue)]
    public int End { get; set; }
}