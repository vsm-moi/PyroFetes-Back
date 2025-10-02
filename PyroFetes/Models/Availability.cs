using System.ComponentModel.DataAnnotations;

namespace PyroFetes.Models;

public class Availability
{
    [Key]    public int Id { get; set; }
    [Required] public string AvailabilityDate { get; set; }
    [Required] public string DeliveryDate { get; set; }
    [Required] public string ExpirationDate { get; set; }
    [Required] public string RenewallDate { get; set; }
}