using System.ComponentModel.DataAnnotations;

namespace PyroFetes.Models;

public class ExperienceLevel
{
    [Key] public int Id { get; set; }
    [Required, MaxLength(100)] public string? Label { get; set; }
    
    public Staff? Staff { get; set; }
    [Required] public int StaffId { get; set; }
}