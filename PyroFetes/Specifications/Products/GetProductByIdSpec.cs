using Ardalis.Specification;
using PyroFetes.Models;

namespace PyroFetes.Specifications.Products;

public sealed class GetProductByIdSpec : Specification<Product>
{
    public GetProductByIdSpec(int? productId)
    {
        Query
            .Where(p => p.Id == productId);
    }
}