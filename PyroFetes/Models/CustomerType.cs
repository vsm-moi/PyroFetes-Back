using System.ComponentModel.DataAnnotations;

namespace PyroFetes.Models;

public class CustomerType
{
    [Key]  public int Id { get; set; }
    [Required] public string? Price { get; set; }
    //RELATIONS PTN
    public List<Customer>? Customers { get; set; }
}