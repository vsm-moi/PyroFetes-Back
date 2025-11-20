using Ardalis.Specification;
using PyroFetes.Models;

namespace PyroFetes.Specifications.PurchaseOrders;

public sealed class GetPurchaseOrderByIdSpec : Specification<PurchaseOrder>
{
    public GetPurchaseOrderByIdSpec(int purchaseOrderId)
    {
        Query
            .Include(po => po.PurchaseProducts)
            .Where(po => po.Id == purchaseOrderId);
    }
}