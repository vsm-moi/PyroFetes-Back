using Ardalis.Specification;
using PyroFetes.Models;

namespace PyroFetes.Specifications.WarehouseProducts;

public sealed class GetProductTotalQuantitySpec : Specification<WarehouseProduct>
{
    public GetProductTotalQuantitySpec(int productId)
    {
        Query
            .Where(wp => wp.ProductId == productId);
    }
}