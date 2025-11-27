using System.ComponentModel.DataAnnotations;

namespace PyroFetes.Models;

public class User
{
    [Key] public int Id { get; set; }
    [Required, MaxLength(100)] public string? Name { get; set; }
    [Required, MaxLength(60)] public string? Password { get; set; }
    [Required, MaxLength(100)] public string? Salt { get; set; }
    [Required, MaxLength(100)] public string? Email { get; set; }
    [Required, MaxLength(100)] public string? Fonction { get; set; }
}