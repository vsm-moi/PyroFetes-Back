using Ardalis.Specification;
using PyroFetes.Models;

namespace PyroFetes.Specifications.PurchaseOrders;

public sealed class GetPurchaseOrderByIdSpec : SingleResultSpecification<PurchaseOrder>
{
    public GetPurchaseOrderByIdSpec(int purchaseOrderId)
    {
        Query
            .Include(x => x.PurchaseProducts!)
            .ThenInclude(x => x.Product)
            .Where(x => x.Id == purchaseOrderId);
    }
}