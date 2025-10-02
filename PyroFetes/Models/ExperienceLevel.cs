using System.ComponentModel.DataAnnotations;

namespace PyroFetes.Models;

public class ExperienceLevel
{
    [Key]    public int Id { get; set; }
    [Required] public string Label { get; set; }
}