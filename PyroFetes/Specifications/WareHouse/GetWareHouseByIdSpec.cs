using Ardalis.Specification;
using PyroFetes.Models;

namespace PyroFetes.Specifications.WareHouse;

public class GetWareHouseByIdSpec : SingleResultSpecification<Warehouse>
{
    public GetWareHouseByIdSpec(int id)
    {
        Query
            .Where(x => x.Id == id);
    }
}