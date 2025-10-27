using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using PyroFetes.DTO.User.Response;

namespace PyroFetes.Endpoints.User;

public class GetUserRequest
{
    public int Id { get; set; }
}

public class GetUserEndpoint(PyroFetesDbContext database) : Endpoint<GetUserRequest, GetUserDto>
{
    public override void Configure()
    {
        Get("/api/users/{@Id}", x => new {x.Id});
    }

    public override async Task HandleAsync(GetUserRequest req, CancellationToken ct)
    {
        var user = await database.Users
            .SingleOrDefaultAsync(x => x.Id == req.Id, ct);

        if (user == null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }
        
        GetUserDto responseDto = new()
        {
            Id = user.Id,
            Name = user.Name,
            Password = user.Password,
            Salt = user.Salt,
            Email = user.Email,
            Fonction = user.Fonction
        };
        
        await Send.OkAsync(responseDto, ct);
    }
}