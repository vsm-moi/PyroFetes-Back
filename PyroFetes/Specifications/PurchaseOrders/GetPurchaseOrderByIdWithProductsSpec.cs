using Ardalis.Specification;
using PyroFetes.Models;

namespace PyroFetes.Specifications.PurchaseOrders;

public class GetPurchaseOrderByIdWithProductsSpec : SingleResultSpecification<PurchaseOrder>
{
    public GetPurchaseOrderByIdWithProductsSpec(int purchaseOrderId)
    {
        Query
            .Where(x => x.Id == purchaseOrderId)
            .Include(x => x.PurchaseProducts!)
            .ThenInclude(p => p.Product)
            .ThenInclude(p=> p!.Prices);
    }
}   