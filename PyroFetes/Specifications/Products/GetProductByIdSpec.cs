using Ardalis.Specification;
using PyroFetes.Models;

namespace PyroFetes.Specifications.Products;

public sealed class GetProductByIdSpec : SingleResultSpecification<Product>
{
    public GetProductByIdSpec(int productId)
    {
        Query
            .Where(p => p.Id == productId)
            .Include(p => p.Prices);
    }
}