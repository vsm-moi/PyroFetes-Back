using Microsoft.EntityFrameworkCore;

namespace PyroFetes.Models;

[PrimaryKey(nameof(ContactId), nameof(ProviderId))]
public class ProviderContact
{
    public int ProviderId { get; set; }
    public Provider? Provider { get; set; }
    public int ContactId { get; set; }
    public Contact? Contact { get; set; }
}