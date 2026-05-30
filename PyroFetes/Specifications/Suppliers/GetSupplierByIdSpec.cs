using Ardalis.Specification;
using PyroFetes.Models;

namespace PyroFetes.Specifications.Suppliers;

public sealed class GetSupplierByIdSpec : SingleResultSpecification<Supplier>
{
    public GetSupplierByIdSpec(int? supplierId)
    {
        Query
            .Include(x => x.Prices!)
            .ThenInclude(p => p.Product)
            .Where(x => x.Id == supplierId);
    }
}