using Microsoft.EntityFrameworkCore;

namespace PyroFetes.Models;

[PrimaryKey(nameof(ContactId), nameof(StaffId))]
public class StaffContact
{
    public int StaffId { get; set; }
    public Staff? Staff { get; set; }
    public int ContactId { get; set; }
    public Contact? Contact { get; set; }
}