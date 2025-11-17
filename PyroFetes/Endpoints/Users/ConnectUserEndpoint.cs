using FastEndpoints;
using FastEndpoints.Security;
using Microsoft.EntityFrameworkCore;
using PyroFetes.DTO.User.Request;
using PyroFetes.DTO.User.Response;
using PyroFetes.Models;

namespace PyroFetes.Endpoints.Users;

public class ConnectUserEndpoint(PyroFetesDbContext database) : Endpoint<ConnectUserDto, GetTokenDto>
{
    public override void Configure()
    {
        Post("/api/users/connect");
        AllowAnonymous();
    }

    public override async Task HandleAsync(ConnectUserDto req, CancellationToken ct)
    {
        User? user = await database.Users.SingleOrDefaultAsync(x => x.Name == req.Name, ct);

        if (user == null)
        {
            await Send.UnauthorizedAsync(ct);
            return;
        }
        
        if (BCrypt.Net.BCrypt.Verify(req.Password + user.Salt, user.Password))
        {
            string jwtToken = JwtBearer.CreateToken(
                o =>
                {
                    o.SigningKey = "ThisIsASuperSecretJwtKeyThatIsAtLeast32CharsLong";
                    o.ExpireAt = DateTime.UtcNow.AddMinutes(15);
                    if (user.Fonction != null) o.User.Roles.Add(user.Fonction);
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