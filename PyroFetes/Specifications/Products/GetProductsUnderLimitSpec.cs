using Ardalis.Specification;
using PyroFetes.Models;

namespace PyroFetes.Specifications.Products;

public sealed class GetProductsUnderLimitSpec : Specification<Product>
{
    public GetProductsUnderLimitSpec()
    {
        Query
            .Include(p => p.QuotationProducts)
            .Where(p => p.QuotationProducts != null && p.QuotationProducts.Any(q => q.Quantity < p.MinimalQuantity));
    }
}