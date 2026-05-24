using Ardalis.Specification;
using PyroFetes.Models;

namespace PyroFetes.Specifications.Quotations;

public class GetQuotationByIdWithProductsSpec : SingleResultSpecification<Quotation>
{
    public GetQuotationByIdWithProductsSpec(int quotationId)
    {
        Query
            .Where(x => x.Id == quotationId)
            .Include(x => x.QuotationProducts!)
            .ThenInclude(p => p.Product);
    }
}