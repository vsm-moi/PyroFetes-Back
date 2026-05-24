using System.ComponentModel.DataAnnotations;

namespace PyroFetes.Models;

public class Customer
{
    [Key] public int Id { get; set; }
    [Required, MaxLength(200)] public string? Note { get; set; }

    //Relations
    [Required] public int CustomerTypeId { get; set; }
    public CustomerType? CustomerType { get; set; }

    public List<Contact>? Contacts { get; set; }
    public List<Quotation>? Quotations { get; set; }
}