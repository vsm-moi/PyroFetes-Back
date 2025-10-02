using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace API.Models;

[PrimaryKey(nameof(ProductId), nameof(EffectId))]
public class ProductEffect
{
    public Product? Product { get; set; }
    [Required] public int ProductId { get; set; }

    public Effect? Effect { get; set; }
    [Required] public int EffectId { get; set; }

}