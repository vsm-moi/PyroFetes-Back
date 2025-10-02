using System.ComponentModel.DataAnnotations;

namespace PyroFetes.Models;

public class HistoryOfApproval
{
    [Key]    public int Id { get; set; }
    [Required] public string ExpirationDate { get; set; }
    [Required] public string DeliveryDate { get; set; }
}