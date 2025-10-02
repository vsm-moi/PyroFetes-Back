using System.ComponentModel.DataAnnotations;

namespace PyroFetes.Models;

public class Staff
{
    [Key] public int Id { get; set; }

    [Required, MaxLength(60)]
    public string FirstName { get; set; } = null!;

    [Required, MaxLength(60)]
    public string LastName { get; set; } = null!;

    [MaxLength(100)]
    public string? Profession { get; set; }

    [EmailAddress, MaxLength(120)]
    public string? Email { get; set; }

    public ICollection<Show> Shows { get; set; } = new List<Show>();
}