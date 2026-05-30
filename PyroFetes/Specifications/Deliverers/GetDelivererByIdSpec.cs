using Ardalis.Specification;
using PyroFetes.Models;

namespace PyroFetes.Specifications.Deliverers;

public sealed class GetDelivererByIdSpec : SingleResultSpecification<Deliverer>
{
    public GetDelivererByIdSpec(int delivererId)
    {
        Query
            .Where(x => x.Id == delivererId);
    }
}