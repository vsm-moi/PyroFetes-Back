using Ardalis.Specification;
using PyroFetes.Models;

namespace PyroFetes.Specifications.PurchaseProducts;

public sealed class GetPurchaseProductByProductIdAndPurchaseOrderIdSpec : Specification<PurchaseProduct>
{
    public GetPurchaseProductByProductIdAndPurchaseOrderIdSpec(int  productId, int purchaseOrderId)
    {
        Query
            .Where(p => p.ProductId == productId && p.PurchaseOrderId == purchaseOrderId);
    }
}