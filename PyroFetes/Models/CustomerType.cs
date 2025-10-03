using System.ComponentModel.DataAnnotations;

namespace PyroFetes.Models;

public class CustomerType
{
    [Key]  public int Id { get; set; }
    [Required] public decimal Price { get; set; }
    
    public List<Customer>? Customers { get; set; }
}