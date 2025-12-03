using Ardalis.Specification;
using PyroFetes.Models;

namespace PyroFetes.Specifications.DeliveryNotes;

public class GetDeliveryNoteByIdWithProductsSpec : Specification<DeliveryNote>
{
    public GetDeliveryNoteByIdWithProductsSpec(int deliveryNoteId)
    {
        Query
            .Where(d => d.Id == deliveryNoteId)
            .Include(d => d.ProductDeliveries!)
            .ThenInclude(dp => dp.Product);
    }
}