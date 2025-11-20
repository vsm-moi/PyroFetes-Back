using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using PyroFetes.DTO.User.Response;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Specifications.Users;

namespace PyroFetes.Endpoints.Users;

public class GetUserRequest
{
    public int Id { get; set; }
}

public class GetUserEndpoint(
    UsersRepository usersRepository,
    AutoMapper.IMapper mapper) : Endpoint<GetUserRequest, GetUserDto>
{
    public override void Configure()
    {
        Get("/users/{@Id}", x => new {x.Id});
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetUserRequest req, CancellationToken ct)
    {
        User? user = await usersRepository.FirstOrDefaultAsync(new GetUserByIdSpec(req.Id), ct);

        if (user == null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }
        
        await Send.OkAsync(mapper.Map<GetUserDto>(user), ct);
    }
}