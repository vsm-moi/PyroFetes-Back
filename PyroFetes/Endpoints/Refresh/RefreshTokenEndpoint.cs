using System.IdentityModel.Tokens.Jwt;
using FastEndpoints;
using FastEndpoints.Security;
using PyroFetes.DTO.Refresh.Request;
using PyroFetes.DTO.Refresh.Response;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Specifications.Users;

namespace PyroFetes.Endpoints.Refresh;

public class RefreshTokenEndpoint(UsersRepository usersRepository) : Endpoint<RefreshTokenDto, GetRefreshTokenDto>
{
    public override void Configure()
    {
        Post("/refresh");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(RefreshTokenDto req, CancellationToken ct)
    {
        try
        { 
            JwtSecurityTokenHandler handler = new();
            JwtSecurityToken? token = handler.ReadJwtToken(req.Token);
            string? username = token.Claims.FirstOrDefault(c => c.Type == "Name")?.Value;

            if (string.IsNullOrWhiteSpace(username))
            {
                await Send.UnauthorizedAsync(ct);
                return;
            }

            User? login = await usersRepository.SingleOrDefaultAsync(new GetUserByNameSpec(username), ct);
            if (login == null)
            {
                await Send.UnauthorizedAsync(ct);
                return;
            }
            
            string jwtToken = JwtBearer.CreateToken(o =>
            {
                o.SigningKey = "v9!Qx7#Lk2@pZ8$wR6!tN5%uF3&cD9^mH1*eY4";
                o.ExpireAt = DateTime.UtcNow.AddMinutes(15);
                if (login.Fonction is not null) o.User.Roles.Add(login.Fonction);
                o.User.Claims.Add(("Name", login.Name)!);
                o.User.Claims.Add(("Id", login.Id.ToString())!);
            });

            GetRefreshTokenDto responseDto = new()
            {
                Token = jwtToken
            };
            
            await Send.OkAsync(responseDto, ct);
        }
        catch
        {
            await Send.UnauthorizedAsync(ct);
        }
    }
}