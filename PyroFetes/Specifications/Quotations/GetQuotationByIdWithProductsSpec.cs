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
            .ThenInclude(x => x.Product)
            .ThenInclude(x => x!.Prices)
            .Include(x => x.Customer)
            .ThenInclude(x => x!.CustomerType);
    }
}