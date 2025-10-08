using System.ComponentModel.DataAnnotations;

namespace PyroFetes.Models;

public class Availability
{
    [Key] public int Id { get; set; }
    [Required] public DateOnly AvailabilityDate { get; set; }
    [Required] public DateOnly DeliveryDate { get; set; }
    [Required] public DateOnly ExpirationDate { get; set; }
    [Required] public DateOnly RenewallDate { get; set; }
    
    public List<StaffAvailability>? StaffAvailabilities { get; set; }
}