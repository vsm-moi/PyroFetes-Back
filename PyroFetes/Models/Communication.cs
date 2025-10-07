using System.ComponentModel.DataAnnotations;

namespace PyroFetes.Models;

public class Communication
{
    [Key]   public int Id { get; set; }
    [Required, MaxLength(100)] public string? Calling { get; set; }
    [Required, MaxLength(100)] public string? Email { get; set; }
    [Required, MaxLength(300)] public string? Meeting { get; set; }
    
    [Required] public int ContactId { get; set; }
    public Contact? Contact { get; set; }
}