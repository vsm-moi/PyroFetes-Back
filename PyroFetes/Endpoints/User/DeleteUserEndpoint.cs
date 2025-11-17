using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace PyroFetes.Endpoints.User;

public class DeleteUserRequest
{
    public int Id { get; set; }
}

public class DeleteUserEndpoint(PyroFetesDbContext database) : Endpoint<DeleteUserRequest>
{
    public override void Configure()
    {
        Delete("/api/users/{@Id}", x => new {x.Id});
        AllowAnonymous();
    }

    public override async Task HandleAsync(DeleteUserRequest req, CancellationToken ct)
    {
        var user = await database.Users.SingleOrDefaultAsync(x => x.Id == req.Id, ct);

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