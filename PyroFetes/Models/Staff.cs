using System.ComponentModel.DataAnnotations;

namespace PyroFetes.Models;

public class Staff
{
    [Key] public int Id { get; set; }
    [Required, MaxLength(60)] public string FirstName { get; set; } = null!;
    [Required, MaxLength(60)] public string LastName { get; set; } = null!;
    [Required, MaxLength(100)] public string? Profession { get; set; }
    [Required, MaxLength(120)] public string? Email { get; set; }
    [Required, MaxLength(100)] public string? F4T2NumberApproval { get; set; }
    [Required] public DateOnly F4T2ExpirationDate { get; set; }
    
    public List<ShowStaff>? ShowStaffs { get; set; }
}