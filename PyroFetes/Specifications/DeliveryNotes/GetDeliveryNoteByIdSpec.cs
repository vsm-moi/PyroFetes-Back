using Ardalis.Specification;
using PyroFetes.Models;

namespace PyroFetes.Specifications.DeliveryNotes;

public sealed class GetDeliveryNoteByIdSpec : SingleResultSpecification<DeliveryNote>
{
    public GetDeliveryNoteByIdSpec(int deliveryNoteId)
    {
        Query
            .Include(x => x.Deliverer)
            .Include(x => x.ProductDeliveries!)
            .ThenInclude(x => x.Product)
            .Where(x => x.Id == deliveryNoteId);
    }
}