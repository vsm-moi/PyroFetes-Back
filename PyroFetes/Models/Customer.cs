using System.ComponentModel.DataAnnotations;

namespace PyroFetes.Models;

public class Customer
{
    [Key] public int Id { get; set; }
    [Required] public string? Note { get; set; }
    
    //Relations
    public int CustomerTypeId { get; set; }
    public CustomerType? CustomerType { get; set; }
    
    public int ContactId { get; set; }
    public Contact? Contact { get; set; }
    
    public List<CustomerContact>? CustomerContacts { get; set; }
}
