using Ardalis.Specification;
using PyroFetes.Models;

namespace PyroFetes.Specifications.Suppliers;

public sealed class GetSupplierByIdSpec : Specification<Supplier>
{
    public GetSupplierByIdSpec(int? supplierId)
    {
        Query
            .Where(x => x.Id == supplierId);
    }
}