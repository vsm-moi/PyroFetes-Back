using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PyroFetes.Models;

[PrimaryKey(nameof(ProductId), nameof(QuotationId))]
public class QuotationProduct
{
    [Required] public int ProductId { get; set; }
    [Required] public int QuotationId { get; set; }
    [Required] public int Quantity { get; set; }   
    
    public Product? Product { get; set; }
    public Quotation? Quotation { get; set; }
}