using System.ComponentModel.DataAnnotations;

namespace PyroFetes.Models;

public class CustomerType
{
    [Key] public int Id { get; set; }
    [Required, MaxLength(100)] public string? Label { get; set; }

    public List<Customer>? Customers { get; set; }
}