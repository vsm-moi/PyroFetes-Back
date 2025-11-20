using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using PasswordGenerator;
using PyroFetes.DTO.User.Request;
using PyroFetes.DTO.User.Response;
using PyroFetes.Models;
using PyroFetes.Repositories;
using PyroFetes.Specifications.Users;

namespace PyroFetes.Endpoints.Users;

public class UpdateUserEndpoint(
    UsersRepository usersRepository,
    AutoMapper.IMapper mapper) : Endpoint<UpdateUserDto, GetUserDto>
{
    public override void Configure()
    {
        Put("/users/{@Id}", x => new {x.Id});
        AllowAnonymous();
    }

    public override async Task HandleAsync(UpdateUserDto req, CancellationToken ct)
    {
        User? user = await usersRepository.FirstOrDefaultAsync(new GetUserByIdSpec(req.Id), ct);
        User? ckeckName = await usersRepository.FirstOrDefaultAsync(new GetUserByNameSpec(req.Name!), ct);

        if (user == null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }
        
        if (ckeckName != null)
        {
            await Send.StringAsync("Ce nom d'utilisateur existe déjà.",409, cancellation: ct);
            return;
        }

        string? salt = new Password().IncludeLowercase().IncludeUppercase().IncludeNumeric().LengthRequired(24).Next();
        
        user.Name = req.Name;
        user.Password = BCrypt.Net.BCrypt.HashPassword(req.Password + salt);
        user.Salt = salt;
        user.Email = req.Email;
        user.Fonction = req.Fonction;
        
        await usersRepository.UpdateAsync(user, ct);
        
        await Send.OkAsync(mapper.Map<GetUserDto>(user), ct);
    }
}