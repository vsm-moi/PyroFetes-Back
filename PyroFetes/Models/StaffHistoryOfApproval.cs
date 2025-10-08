using Microsoft.EntityFrameworkCore;

namespace PyroFetes.Models;

[PrimaryKey(nameof(HistoryOfApprovalId), nameof(StaffId))]
public class StaffHistoryOfApproval
{
    public int StaffId { get; set; }
    public Staff? Staff { get; set; }
    public int HistoryOfApprovalId { get; set; }
    public HistoryOfApproval? HistoryOfApproval { get; set; }
}