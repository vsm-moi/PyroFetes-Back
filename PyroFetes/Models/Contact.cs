using System.ComponentModel.DataAnnotations;

namespace PyroFetes.Models;

public class Contact
{
    [Key] public int Id { get; set; }
    [Required, MaxLength(100)] public string? LastName { get; set; }
    [Required, MaxLength(100)] public string? FirstName { get; set; }
    [Required, MaxLength(100)] public string? Email { get; set; }
    [Required, MaxLength(30)] public string? PhoneNumber { get; set; }
    [Required, MaxLength(100)] public string? Address { get; set; }
    [Required] public int ZipCode { get; set; }
    [Required, MaxLength(100)] public string? City { get; set; }
    [Required, MaxLength(100)] public string? Role { get; set; }
    
    public Customer? Customer { get; set; }
    [Required] public int CustomerId { get; set; }
    
    public List<Communication>? Communications { get; set; }
}