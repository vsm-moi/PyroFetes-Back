using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PyroFetes.Models;

[PrimaryKey(nameof(StaffId), nameof(ShowId))]
public class ShowStaff
{
    public Staff? Staff { get; set; }
    [Required] public int StaffId { get; set; }

    public Show? Show { get; set; }
    [Required] public int ShowId { get; set; }
}