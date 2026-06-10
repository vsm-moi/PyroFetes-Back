using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PyroFetes.Models;

[PrimaryKey(nameof(ProductId), nameof(InvoiceId))]
public class InvoiceProduct
{
    [Required] public int ProductId { get; set; }
    [Required] public int InvoiceId { get; set; }
    [Required] public int Quantity { get; set; }

    public Product? Product { get; set; }
    public Invoice? Invoice { get; set; }
}