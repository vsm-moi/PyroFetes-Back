using System.ComponentModel.DataAnnotations;
using API.Models;

namespace API.Class;

public class Supplier
{
    [Key] public int Id { get; set; }
    [Required, MaxLength(100)] public string Name { get; set; }
    [Required] public string Email { get; set; }
    [Required] public string PhoneNumber { get; set; }
    [Required] public string Adress { get; set; }
    [Required] public int ZipCode { get; set; }
    [Required] public string City { get; set; }
    
}