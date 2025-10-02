using System.ComponentModel.DataAnnotations;

namespace PyroFetes.Models;

public class Contact
{
    [Key] public int Id { get; set; }
    [Required] public string LastName { get; set; }
    [Required] public string FirstName { get; set; }
    [Required] public string Email { get; set; }
    [Required] public string PhoneNumber { get; set; }
    [Required] public string Address { get; set; }
    [Required] public string Role { get; set; }
    
    //RELATIONS DE CON LA
    public int CommunicationID { get; set; }
    public Communication? Communication { get; set; }
}