using Ardalis.Specification;
using PyroFetes.Models;

namespace PyroFetes.Specifications.Quotations;

public class GetAllQuotationSpec : Specification<Quotation>
{
    public GetAllQuotationSpec()
    {
        Query
            .Where(x => true)
            .OrderByDescending(x => x.Id);
    }
}