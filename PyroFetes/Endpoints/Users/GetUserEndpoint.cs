using FastEndpoints;
using PyroFetes.DTO.User.Response;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Specifications.Users;

namespace PyroFetes.Endpoints.Users;

public class GetUserEndpoint(UsersRepository usersRepository, AutoMapper.IMapper mapper) : EndpointWithoutRequest<GetUserDto>
{
    public override void Configure()
    {
        Get("/user/");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        int userId = int.Parse(User.FindFirst("Id")!.Value);
        User? user = await usersRepository.SingleOrDefaultAsync(new GetUserByIdSpec(userId), ct);

        if (user is null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }

        await Send.OkAsync(mapper.Map<GetUserDto>(user), ct);
    }
}