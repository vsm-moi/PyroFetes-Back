using System.ComponentModel.DataAnnotations;

namespace PyroFetes.Models;

public class Supplier
{
    [Key] public int Id { get; set; }
    [Required, MaxLength(100)] public string? Name { get; set; }
    [Required] public string? Email { get; set; }
    [Required] public string? Phone { get; set; }
    [Required] public string? Address { get; set; }
    [Required] public int ZipCode { get; set; }
    [Required] public string? City { get; set; }
    [Required] public int DeliveryDelay { get; set; }
}