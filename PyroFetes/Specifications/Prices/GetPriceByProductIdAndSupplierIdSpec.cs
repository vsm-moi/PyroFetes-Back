using Ardalis.Specification;
using PyroFetes.Models;

namespace PyroFetes.Specifications.Prices;

public sealed class GetPriceByProductIdAndSupplierIdSpec : Specification<Price>
{
    public GetPriceByProductIdAndSupplierIdSpec(int? productId, int? supplierId)
    {
        Query
            .Where(p => p.ProductId == productId && p.SupplierId == supplierId);
    }
}