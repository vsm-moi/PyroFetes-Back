using Ardalis.Specification;
using PyroFetes.Models;

namespace PyroFetes.Specifications.DeliveryNotes;

public class GetAllDeliveryNoteSpec : Specification<DeliveryNote>
{
    public GetAllDeliveryNoteSpec()
    {
        Query
            .Include(x => x.Deliverer)
            .Include(x => x.ProductDeliveries)!
            .ThenInclude(x => x.Product)
            .Where(x => true);
    }
}