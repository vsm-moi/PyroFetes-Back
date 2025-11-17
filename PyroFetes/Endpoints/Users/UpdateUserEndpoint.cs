using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using PasswordGenerator;
using PyroFetes.DTO.User.Request;
using PyroFetes.DTO.User.Response;
using PyroFetes.Models;

namespace PyroFetes.Endpoints.Users;

public class UpdateUserEndpoint(PyroFetesDbContext database) : Endpoint<UpdateUserDto, GetUserDto>
{
    public override void Configure()
    {
        Put("/api/users/{@Id}", x => new {x.Id});
    }

    public override async Task HandleAsync(UpdateUserDto req, CancellationToken ct)
    {
        User? user = await database.Users.SingleOrDefaultAsync(x => x.Id == req.Id, ct);
        User? ckeckName = await database.Users.SingleOrDefaultAsync(x => x.Name == req.Name, ct);

        if (user == null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }
        
        if (ckeckName != null)
        {
            await Send.StringAsync("Ce nom d'utilisateur existe déjà.",409, cancellation: ct);
            return;
        }

        string? salt = new Password().IncludeLowercase().IncludeUppercase().IncludeNumeric().LengthRequired(24).Next();
        
        user.Name = req.Name;
        user.Password = BCrypt.Net.BCrypt.HashPassword(req.Password + salt);
        user.Salt = salt;
        user.Email = req.Email;
        user.Fonction = req.Fonction;
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