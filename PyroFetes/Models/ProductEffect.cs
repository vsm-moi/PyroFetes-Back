using System.ComponentModel.DataAnnotations;

namespace PyroFetes.Models;

[PrimaryKey(nameof(ProductId), nameof(EffectId))]
public class ProductEffect
{
    [Required] public Product? Product { get; set; }
    [Required] public int ProductId { get; set; }

    [Required] public Effect? Effect { get; set; }
    [Required] public int EffectId { get; set; }

}