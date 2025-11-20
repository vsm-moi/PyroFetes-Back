using Ardalis.Specification;
using PyroFetes.Models;

namespace PyroFetes.Specifications.WarehouseProducts;

public sealed class GetWarehouseProductByProductIdSpec : Specification<WarehouseProduct>
{
    public GetWarehouseProductByProductIdSpec(int productId)
    {
        Query
            .Where(x => x.ProductId == productId);
    }
}