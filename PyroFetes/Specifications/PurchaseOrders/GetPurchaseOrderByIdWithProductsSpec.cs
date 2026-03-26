using Ardalis.Specification;
using PyroFetes.Models;

namespace PyroFetes.Specifications.PurchaseOrders;

public class GetPurchaseOrderByIdWithProductsSpec : Specification<PurchaseOrder>
{
    public GetPurchaseOrderByIdWithProductsSpec(int purchaseOrderId)
    {
        Query
            .Where(p => p.Id == purchaseOrderId)
            .Include(p => p.PurchaseProducts!)
            .ThenInclude(pp => pp.Product)
            .ThenInclude(pp=> pp!.Prices);
    }
}   