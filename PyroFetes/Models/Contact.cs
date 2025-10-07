using System.ComponentModel.DataAnnotations;

namespace PyroFetes.Models;

public class Contact
{
    [Key] public int Id { get; set; }
    [Required, MaxLength(100)] public string? LastName { get; set; }
    [Required, MaxLength(100)] public string? FirstName { get; set; }
    [Required] public string? Email { get; set; }
    [Required] public string? PhoneNumber { get; set; }
    [Required] public string? Address { get; set; }
    [Required] public string? ZipCode { get; set; }
    [Required] public string? City { get; set; }
    [Required] public string? Role { get; set; }
    
    public int CommunicationId { get; set; }
    public Communication? Communication { get; set; }
    
    public List<CustomerContact>? CustomerContacts { get; set; }
}