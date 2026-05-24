using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PyroFetes.Models;

[PrimaryKey(nameof(ShowId), nameof(SoundId))]
public class SoundTimecode
{
    [Required] public int ShowId { get; set; }
    public Show? Show { get; set; }
    [Required] public int SoundId { get; set; }
    public Sound? Sound { get; set; }

    [Required] public decimal Start { get; set; }
    [Required] public decimal End { get; set; }
}