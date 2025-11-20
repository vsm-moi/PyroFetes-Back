using FastEndpoints;
using PasswordGenerator;
using PyroFetes.DTO.User.Request;
using PyroFetes.DTO.User.Response;
using PyroFetes.Models;
using PyroFetes.Repositories;

namespace PyroFetes.Endpoints.Users;

public class CreateUserEndpoint(
    UsersRepository usersRepository,
    AutoMapper.IMapper mapper) : Endpoint<CreateUserDto, GetUserDto>
{
    public override void Configure()
    {
        Post("/api/users");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateUserDto req, CancellationToken ct)
    {
        string? salt = new Password().IncludeLowercase().IncludeUppercase().IncludeNumeric().LengthRequired(24).Next();
        
        User user = new User()
        {
            Name = req.Name,
            Password = BCrypt.Net.BCrypt.HashPassword(req.Password + salt),
            Salt = salt,
            Email = req.Email,
            Fonction = req.Fonction
        };
        
        await usersRepository.AddAsync(user, ct);
        
        await Send.OkAsync(mapper.Map<GetUserDto>(user), ct);
    }
}