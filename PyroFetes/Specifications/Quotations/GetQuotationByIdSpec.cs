using Ardalis.Specification;
using PyroFetes.Models;

namespace PyroFetes.Specifications.Quotations;

public sealed class GetQuotationByIdSpec : Specification<Quotation>
{
    public GetQuotationByIdSpec(int quotationId)
    {
        Query
            .Include(q => q.QuotationProducts)
            .Where(x => x.Id == quotationId);
    }
}