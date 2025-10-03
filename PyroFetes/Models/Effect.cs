using System.ComponentModel.DataAnnotations;

namespace PyroFetes.Models;

public class Effect
{
    [Key] public int Id  { get; set; }
    [Required] public string? Label  { get; set; }
}