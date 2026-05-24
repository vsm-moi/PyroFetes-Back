using FastEndpoints;
using PyroFetes.DTO.User.Request;
using PyroFetes.DTO.User.Response;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Specifications.Users;

namespace PyroFetes.Endpoints.Users;

public class PatchUserPasswordEndpoint(UsersRepository usersRepository, AutoMapper.IMapper mapper) : Endpoint<PatchUserPasswordDto, GetUserDto>
{
    public override void Configure()
    {
        Patch("/users/{@Id}/password", x => new { x.Id });
        AllowAnonymous();
    }

    public override async Task HandleAsync(PatchUserPasswordDto req, CancellationToken ct)
    {
        User? user = await usersRepository.SingleOrDefaultAsync(new GetUserByIdSpec(req.Id), ct);

        if (user is null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }

        user.Password = BCrypt.Net.BCrypt.HashPassword(req.Password + user.Salt);
        await usersRepository.UpdateAsync(user, ct);

        await Send.NoContentAsync(ct);
    }
}