using Ardalis.Specification;
using PyroFetes.Models;

namespace PyroFetes.Specifications.DeliveryNotes;

public sealed class GetDeliveryNoteByIdSpec : Specification<DeliveryNote>
{
    public GetDeliveryNoteByIdSpec(int deliveryNoteId)
    {
        Query
            .Where(x => x.Id == deliveryNoteId);
    }
}