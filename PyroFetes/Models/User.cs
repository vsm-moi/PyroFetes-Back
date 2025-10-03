using System.ComponentModel.DataAnnotations;

namespace PyroFetes.Models;

public class User
{
    [Key] public int Id { get; set; }
    [Required, MaxLength(100)] public string? Name { get; set; }
    [Required, MinLength(12)] public string? Password { get; set; }
    [Required] public string? Salt { get; set; }
    [Required] public string? Email { get; set; }
    [Required] public string? Fonction { get; set; }
}