using FastEndpoints;
using PyroFetes.DTO.User.Response;
using PyroFetes.Repositories;

namespace PyroFetes.Endpoints.Users;

public class GetAllUsersEndpoint(UsersRepository usersRepository) : EndpointWithoutRequest<List<GetUserDto>>
{
    public override void Configure()
    {
        Get("/users");
        Roles("Admin");
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await Send.OkAsync(await usersRepository.ProjectToListAsync<GetUserDto>(ct), ct);
    }
}