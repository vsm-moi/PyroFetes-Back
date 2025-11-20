using Ardalis.Specification;
using PyroFetes.Models;

namespace PyroFetes.Specifications.Users;

public sealed class GetUserByNameSpec : Specification<User>
{
    public GetUserByNameSpec(string userName)
    {
        Query
            .Where(x=> x.Name == userName);
    }
}