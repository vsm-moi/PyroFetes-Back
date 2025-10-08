using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PyroFetes.Models;

[PrimaryKey(nameof(ContactId), nameof(ServiceProviderId))]
public class ContactServiceProvider
{
    [Required] public int ContactId { get; set; }
    [Required] public int ServiceProviderId { get; set; }
    
    public Product? Contact { get; set; }
    public DeliveryNote? ServiceProvider { get; set; }
}