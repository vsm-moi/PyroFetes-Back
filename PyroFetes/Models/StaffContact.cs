using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PyroFetes.Models;

[PrimaryKey(nameof(ContactId), nameof(StaffId))]
public class StaffContact
{
    [Required] public int StaffId { get; set; }
    public Staff? Staff { get; set; }
    [Required] public int ContactId { get; set; }
    public Contact? Contact { get; set; }
}