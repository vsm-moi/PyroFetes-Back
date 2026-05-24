using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PyroFetes.Models;

[PrimaryKey(nameof(ProductId), nameof(ColorId))]
public class ProductColor
{
    public Product? Product { get; set; }
    [Required] public int ProductId { get; set; }

    public Color? Color { get; set; }
    [Required] public int ColorId { get; set; }
}