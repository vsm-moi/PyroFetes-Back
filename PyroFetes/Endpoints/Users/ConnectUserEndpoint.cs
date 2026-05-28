using FastEndpoints;
using FastEndpoints.Security;
using Microsoft.EntityFrameworkCore;
using PyroFetes.DTO.User.Request;
using PyroFetes.DTO.User.Response;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Specifications.Users;

namespace PyroFetes.Endpoints.Users;

public class ConnectUserEndpoint(UsersRepository usersRepository) : Endpoint<ConnectUserDto, GetTokenDto>
{
    public override void Configure()
    {
        Post("/users/connection");
        AllowAnonymous();
    }

    public override async Task HandleAsync(ConnectUserDto req, CancellationToken ct)
    {
        User? user = await usersRepository.SingleOrDefaultAsync(new GetUserByNameSpec(req.Name!), ct);

        if (user is null)
        {
            await Send.UnauthorizedAsync(ct);
            return;
        }

        if (BCrypt.Net.BCrypt.Verify(req.Password + user.Salt, user.Password))
        {
            string jwtToken = JwtBearer.CreateToken(o =>
            {
                o.SigningKey = "v9!Qx7#Lk2@pZ8$wR6!tN5%uF3&cD9^mH1*eY4";
                o.ExpireAt = DateTime.UtcNow.AddMinutes(15);
                if (user.Fonction is not null) o.User.Roles.Add(user.Fonction);
                o.User.Claims.Add(("Name", user.Name)!);
                o.User.Claims.Add(("Id", user.Id.ToString())!);
            });

            GetTokenDto responseDto = new()
            {
                Token = jwtToken
            };

            await Send.OkAsync(responseDto, ct);
        }
        else await Send.UnauthorizedAsync(ct);
    }
}