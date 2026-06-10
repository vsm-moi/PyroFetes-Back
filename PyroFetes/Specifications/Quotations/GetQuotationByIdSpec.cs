using Ardalis.Specification;
using PyroFetes.Models;

namespace PyroFetes.Specifications.Quotations;

public sealed class GetQuotationByIdSpec : SingleResultSpecification<Quotation>
{
    public GetQuotationByIdSpec(int quotationId)
    {
        Query
            .Include(x => x.QuotationProducts!)
            .ThenInclude(x => x.Product)
            .Include(x => x.Invoices)
            .Include(x => x.Customer)
            .Where(x => x.Id == quotationId);
    }
}