using Ardalis.Specification;
using PyroFetes.Models;

namespace PyroFetes.Specifications.DeliveryNotes;

public class GetDeliveryNoteByIdWithProductsSpec : SingleResultSpecification<DeliveryNote>
{
    public GetDeliveryNoteByIdWithProductsSpec(int deliveryNoteId)
    {
        Query
            .Include(x => x.ProductDeliveries!)
            .ThenInclude(p => p.Product)
            .ThenInclude(x => x!.Prices)
            .Include(x => x.Deliverer)
            .Include(x => x.Supplier)
            .Where(x => x.Id == deliveryNoteId);
    }
}