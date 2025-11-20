using Ardalis.Specification;
using PyroFetes.Models;

namespace PyroFetes.Specifications.QuotationProducts;

public sealed class GetQuotationProductByProductIdAndQuotationIdSpec : Specification<QuotationProduct>
{
    public GetQuotationProductByProductIdAndQuotationIdSpec(int productId, int quotationId)
    {
        Query
            .Where(x => x.ProductId == productId && x.QuotationId == quotationId);
    }
}