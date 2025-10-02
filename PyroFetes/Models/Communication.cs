using System.ComponentModel.DataAnnotations;

namespace PyroFetes.Models;

public class Communication
{
    [Key]   public int Id { get; set; }
    [Required] public string Calling { get; set; }
    [Required] public string Email { get; set; }
    [Required] public string Meeting { get; set; }
    
    //REL
}