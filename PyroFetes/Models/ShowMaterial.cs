using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PyroFetes.Models;

[PrimaryKey(nameof(ShowId), nameof(MaterialId))]
public class ShowMaterial
{
    [Required] public Show? Show { get; set; }
    [Required] public int ShowId { get; set; }

    public Material? Material { get; set; }
    [Required] public int MaterialId { get; set; }
}