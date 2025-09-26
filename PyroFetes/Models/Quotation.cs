using System.ComponentModel.DataAnnotations;

namespace PyroFetes.Models;

public class Quotation
{
    [Key] public int Id { get; set; }
    [Required] public string? Message { get; set; }
    [Required] public string? ConditionsSale { get; set; }
}