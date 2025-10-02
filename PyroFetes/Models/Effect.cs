using System.ComponentModel.DataAnnotations;
using API.Class;

namespace API.Models;

public class Effect
{
    [Key] public int Id  { get; set; }
    [Required] public string Label  { get; set; }
    
}