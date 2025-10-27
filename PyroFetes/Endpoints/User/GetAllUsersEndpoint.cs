using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using PyroFetes.DTO.User.Response;

namespace PyroFetes.Endpoints.User;

public class GetAllUsersEndpoint(PyroFetesDbContext database) : EndpointWithoutRequest<List<GetUserDto>>
{
    public override void Configure()
    {
        Get("/api/users");
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var users = await database.Users
            .Select(users => new GetUserDto()
            {
                Id = users.Id,
                Name = users.Name,
                Password = users.Password,
                Salt = users.Salt,
                Email = users.Email,
                Fonction = users.Fonction
            })
            .ToListAsync(ct);
        
        await Send.OkAsync(users, ct);
    }
}