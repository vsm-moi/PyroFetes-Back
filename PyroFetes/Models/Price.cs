using System.ComponentModel.DataAnnotations;
using API.Class;
using Microsoft.EntityFrameworkCore;

namespace API.Models;

[PrimaryKey(nameof(SupplierId), nameof(ProductId))]
public class Price
{
    [Required] public decimal Label  { get; set; }
    
    [Required] public int SupplierId { get; set; }
    [Required] public Supplier Supplier { get; set; }

    [Required] public int ProductId { get; set; }
    [Required] public Product Product { get; set; }
}