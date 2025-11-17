using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using PyroFetes.Models;

namespace PyroFetes.Endpoints.Users;

public class DeleteUserRequest
{
    public int Id { get; set; }
}

public class DeleteUserEndpoint(PyroFetesDbContext database) : Endpoint<DeleteUserRequest>
{
    public override void Configure()
    {
        Delete("/api/users/{@Id}", x => new {x.Id});
    }

    public override async Task HandleAsync(DeleteUserRequest req, CancellationToken ct)
    {
        User? user = await database.Users.SingleOrDefaultAsync(x => x.Id == req.Id, ct);

        if (user == null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }
        
        database.Users.Remove(user);
        await database.SaveChangesAsync(ct);
        
        await Send.NoContentAsync(ct);
    }
}