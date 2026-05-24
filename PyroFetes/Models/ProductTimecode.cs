using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PyroFetes.Models;

[PrimaryKey(nameof(ProductId), nameof(ShowId))]
public class ProductTimecode
{
    public Product? Product { get; set; }
    [Required] public int ProductId { get; set; }

    public Show? Show { get; set; }
    [Required] public int ShowId { get; set; }

    [Required] public decimal Start { get; set; }
    [Required] public decimal End { get; set; }
}