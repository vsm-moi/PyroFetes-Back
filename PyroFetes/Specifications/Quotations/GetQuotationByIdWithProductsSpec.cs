using Ardalis.Specification;
using PyroFetes.Models;

namespace PyroFetes.Specifications.Quotations;

public class GetQuotationByIdWithProductsSpec : Specification<Quotation>
{
    public GetQuotationByIdWithProductsSpec(int quotationId)
    {
        Query
            .Where(q => q.Id == quotationId)
            .Include(q => q.QuotationProducts!)
            .ThenInclude(qp => qp.Product);
    }
}