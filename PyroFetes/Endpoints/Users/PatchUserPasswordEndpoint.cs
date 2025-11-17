using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using PyroFetes.DTO.User.Request;
using PyroFetes.DTO.User.Response;
using PyroFetes.Models;

namespace PyroFetes.Endpoints.Users;

public class PatchUserPasswordEndpoint(PyroFetesDbContext database) : Endpoint<PatchUserPasswordDto, GetUserDto>
{
    public override void Configure()
    {
        Patch("/api/users/{@Id}/Password", x => new { x.Id });
        AllowAnonymous();
    }

    public override async Task HandleAsync(PatchUserPasswordDto req, CancellationToken ct)
    {
        User? user = await database.Users.SingleOrDefaultAsync(x => x.Id == req.Id, ct);
        if (user == null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }

        user.Password = BCrypt.Net.BCrypt.HashPassword(req.Password + user.Salt);
        await database.SaveChangesAsync(ct);

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