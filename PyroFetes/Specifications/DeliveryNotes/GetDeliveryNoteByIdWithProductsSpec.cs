using Ardalis.Specification;
using PyroFetes.Models;

namespace PyroFetes.Specifications.DeliveryNotes;

public class GetDeliveryNoteByIdWithProductsSpec : SingleResultSpecification<DeliveryNote>
{
    public GetDeliveryNoteByIdWithProductsSpec(int deliveryNoteId)
    {
        Query
            .Where(x => x.Id == deliveryNoteId)
            .Include(x => x.ProductDeliveries!)
            .ThenInclude(p => p.Product);
    }
}