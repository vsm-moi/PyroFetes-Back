using Microsoft.EntityFrameworkCore;

namespace PyroFetes.Models;

[PrimaryKey(nameof(AvailabilityId), nameof(StaffId))]
public class StaffAvailability
{
    public int StaffId { get; set; }
    public Staff? Staff { get; set; }
    public int AvailabilityId { get; set; }
    public Availability? Availability { get; set; }
}