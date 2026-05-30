using FastEndpoints;
using PasswordGenerator;
using PyroFetes.DTO.User.Request;
using PyroFetes.DTO.User.Response;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Specifications.Users;

namespace PyroFetes.Endpoints.Users;

public class UpdateUserEndpoint(UsersRepository usersRepository) : Endpoint<UpdateUserDto, GetUserDto>
{
    public override void Configure()
    {
        Put("/users/{@Id}", x => new { x.Id });
        Roles("Admin");
    }

    public override async Task HandleAsync(UpdateUserDto req, CancellationToken ct)
    {
        User? user = await usersRepository.SingleOrDefaultAsync(new GetUserByIdSpec(req.Id), ct);
        User? ckeckName = await usersRepository.SingleOrDefaultAsync(new GetUserByNameSpec(req.Name!), ct);

        if (user is null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }

        if (ckeckName is not null && ckeckName.Id != user.Id)
        {
            await Send.StringAsync("Ce nom d'utilisateur existe déjà.", 400, cancellation: ct);
            return;
        }

        string? salt = new Password().IncludeLowercase().IncludeUppercase().IncludeNumeric().LengthRequired(24).Next();

        user.Name = req.Name;
        user.Password = BCrypt.Net.BCrypt.HashPassword(req.Password + salt);
        user.Salt = salt;
        user.Email = req.Email;
        user.Fonction = req.Fonction;

        await usersRepository.UpdateAsync(user, ct);

        await Send.NoContentAsync(ct);
    }
}