using Ardalis.Specification;
using PyroFetes.Models;

namespace PyroFetes.Specifications.Prices;

public sealed class GetPriceByProductIdAndSupplierIdSpec : SingleResultSpecification<Price>
{
    public GetPriceByProductIdAndSupplierIdSpec(int? productId, int? supplierId)
    {
        Query
            .Where(x => x.ProductId == productId && x.SupplierId == supplierId);
    }
}