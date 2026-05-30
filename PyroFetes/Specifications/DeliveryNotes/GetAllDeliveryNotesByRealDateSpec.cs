using Ardalis.Specification;
using PyroFetes.Models;

namespace PyroFetes.Specifications.DeliveryNotes;

public class GetAllDeliveryNotesByRealDateSpec : Specification<DeliveryNote>
{
    public GetAllDeliveryNotesByRealDateSpec()
    {
        Query
            .Include(x => x.Deliverer)
            .Include(x => x.ProductDeliveries)!
            .ThenInclude(x => x.Product)
            .Where(x => x.RealDeliveryDate == null)
            .OrderByDescending(x => x.ExpeditionDate);
    }
}