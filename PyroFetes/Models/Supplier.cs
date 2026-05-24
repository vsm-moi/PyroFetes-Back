using System.ComponentModel.DataAnnotations;

namespace PyroFetes.Models;

public class Supplier
{
    [Key] public int Id { get; set; }
    [Required, MaxLength(100)] public string? Name { get; set; }
    [Required, MaxLength(100)] public string? Email { get; set; }
    [Required, MaxLength(30)] public string? Phone { get; set; }
    [Required, MaxLength(100)] public string? Address { get; set; }
    [Required, Length(5, 5)] public string? ZipCode { get; set; }
    [Required, MaxLength(100)] public string? City { get; set; }
    [Required] public int DeliveryDelay { get; set; }

    public List<Price>? Prices { get; set; }
}