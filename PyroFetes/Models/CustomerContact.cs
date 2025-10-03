using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PyroFetes.Models;

[PrimaryKey(nameof(ContactId), nameof(CustomerId))]
public class CustomerContact
{
    public int CustomerId { get; set; }
    public Customer? Customer { get; set; }
    public int ContactId { get; set; }
    public Contact? Contact { get; set; }
}