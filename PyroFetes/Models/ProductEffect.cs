using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PyroFetes.Models;

[PrimaryKey(nameof(ProductId), nameof(EffectId))]
public class ProductEffect
{
    [Required] public Product? Product { get; set; }
    [Required] public int ProductId { get; set; }

    public Effect? Effect { get; set; }
    [Required] public int EffectId { get; set; }

}