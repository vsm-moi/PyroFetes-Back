using FastEndpoints;
using PasswordGenerator;
using PyroFetes.DTO.User.Request;
using PyroFetes.DTO.User.Response;

namespace PyroFetes.Endpoints.User;

public class CreateUserEndpoint(PyroFetesDbContext database) : Endpoint<CreateUserDto, GetUserDto>
{
    public override void Configure()
    {
        Post("/api/users");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateUserDto req, CancellationToken ct)
    {
        string? salt = new Password().IncludeLowercase().IncludeUppercase().IncludeNumeric().LengthRequired(24).Next();
        
        var user = new Models.User()
        {
            Name = req.Name,
            Password = BCrypt.Net.BCrypt.HashPassword(req.Password + salt),
            Salt = salt,
            Email = req.Email,
            Fonction = req.Fonction
        };
        
        database.Users.Add(user);
        
        await database.SaveChangesAsync(ct);
        
        GetUserDto responseDto = new()
        {
            Id = user.Id,
            Name = user.Name,
            Password = user.Password,
            Salt = user.Salt,
            Email = user.Email,
            Fonction = user.Fonction
        };
        
        await Send.OkAsync(responseDto, ct);
    }
}