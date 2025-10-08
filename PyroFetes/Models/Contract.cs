using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PyroFetes.Models;

[PrimaryKey(nameof(ShowId), nameof(ServiceProviderId))]
public class Contract
{
    [Required] public int ShowId { get; set; }
    [Required] public int ServiceProviderId { get; set; }
    [Required] public string? TermsAndConditions { get; set; }

    public Show? Show { get; set; }
    public ServiceProvider? ServiceProvider { get; set; }
}