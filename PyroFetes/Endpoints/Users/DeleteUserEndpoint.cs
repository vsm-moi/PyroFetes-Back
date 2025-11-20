using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Specifications.Users;

namespace PyroFetes.Endpoints.Users;

public class DeleteUserRequest
{
    public int Id { get; set; }
}

public class DeleteUserEndpoint(UsersRepository usersRepository) : Endpoint<DeleteUserRequest>
{
    public override void Configure()
    {
        Delete("/users/{@Id}", x => new {x.Id});
        AllowAnonymous();
    }

    public override async Task HandleAsync(DeleteUserRequest req, CancellationToken ct)
    {
        User? user = await usersRepository.FirstOrDefaultAsync(new GetUserByIdSpec(req.Id), ct);

        if (user == null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }
        
        await usersRepository.DeleteAsync(user, ct);
        
        await Send.NoContentAsync(ct);
    }
}