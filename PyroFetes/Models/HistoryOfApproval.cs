using System.ComponentModel.DataAnnotations;

namespace PyroFetes.Models;

public class HistoryOfApproval
{
    [Key]    public int Id { get; set; }
    [Required] public DateOnly ExpirationDate { get; set; }
    [Required] public DateOnly DeliveryDate { get; set; }
}