using FastEndpoints;
using PasswordGenerator;
using PyroFetes.DTO.User.Request;
using PyroFetes.DTO.User.Response;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Specifications.Users;

namespace PyroFetes.Endpoints.Users;

public class CreateUserEndpoint(UsersRepository usersRepository) : Endpoint<CreateUserDto, GetUserDto>
{
    public override void Configure()
    {
        Post("/users");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateUserDto req, CancellationToken ct)
    {
        User? ckeckName = await usersRepository.SingleOrDefaultAsync(new GetUserByNameSpec(req.Name!), ct);

        if (ckeckName is not null)
        {
            await Send.StringAsync("Ce nom d'utilisateur existe déjà.", 400, cancellation: ct);
            return;
        }

        string? salt = new Password().IncludeLowercase().IncludeUppercase().IncludeNumeric().LengthRequired(24).Next();

        User user = new()
        {
            Name = req.Name,
            Password = BCrypt.Net.BCrypt.HashPassword(req.Password + salt),
            Salt = salt,
            Email = req.Email,
            Fonction = req.Fonction
        };

        await usersRepository.AddAsync(user, ct);
        await Send.NoContentAsync(ct);
    }
}