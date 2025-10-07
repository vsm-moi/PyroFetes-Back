using System.ComponentModel.DataAnnotations;

namespace PyroFetes.Models;

public class Quotation
{
    [Key] public int Id { get; set; }
    [Required, MaxLength(200)] public string? Message { get; set; }
    [Required, MaxLength(300)] public string? ConditionsSale { get; set; }
    
    public List<QuotationProduct>? QuotationProducts { get; set; }
}