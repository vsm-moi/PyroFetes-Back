using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;

namespace PyroFetes.Models;

[PrimaryKey(nameof(ProductId), nameof(SupplierId))]
public class Price
{
    [Required] public int ProductId { get; set; }
    [Required] public int SupplierId { get; set; }
    [Required] public decimal SellingPrice { get; set; }

    public Product? Product { get; set; }
    public Supplier? Supplier { get; set; }
}