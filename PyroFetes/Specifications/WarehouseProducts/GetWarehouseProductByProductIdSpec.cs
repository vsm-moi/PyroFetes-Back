using Ardalis.Specification;
using PyroFetes.Models;

namespace PyroFetes.Specifications.WarehouseProducts;

public sealed class GetWarehouseProductByProductIdSpec : SingleResultSpecification<WarehouseProduct>
{
    public GetWarehouseProductByProductIdSpec(int productId, int? warehouseId = null)
    {
        Query
            .Where(x => x.ProductId == productId);

        if (warehouseId.HasValue)
        {
            Query.Where(x => x.WarehouseId == warehouseId.Value);
        }
    }
}