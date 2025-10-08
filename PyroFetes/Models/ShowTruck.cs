using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PyroFetes.Models;

[PrimaryKey(nameof(ShowId), nameof(TruckId))]
public class ShowTruck
{
    public Show? Show { get; set; }
    [Required] public int ShowId { get; set; }

    public Truck? Truck { get; set; }
    [Required] public int TruckId { get; set; }
}