using System.ComponentModel.DataAnnotations;

namespace PyroFetes.Models;

public class Staff
{
    [Key]   public int Id { get; set; }
    [Required] public string F4T2NumberApproval { get; set; }
    [Required] public string F4T2ExpirationDate { get; set; }
}