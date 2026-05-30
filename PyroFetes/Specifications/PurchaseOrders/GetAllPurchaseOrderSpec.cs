using Ardalis.Specification;
using PyroFetes.Models;

namespace PyroFetes.Specifications.PurchaseOrders;

public class GetAllPurchaseOrderSpec : Specification<PurchaseOrder>
{
    public GetAllPurchaseOrderSpec()
    {
        Query
            .Where(x => true)
            .OrderByDescending(x => x.Id);
    }
}