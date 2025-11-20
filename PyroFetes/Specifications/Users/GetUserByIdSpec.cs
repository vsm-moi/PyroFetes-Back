using Ardalis.Specification;
using PyroFetes.Models;

namespace PyroFetes.Specifications.Users;

public sealed class GetUserByIdSpec : Specification<User>
{
    public GetUserByIdSpec(int userId)
    {
        Query
            .Where(x => x.Id == userId);
    }
}