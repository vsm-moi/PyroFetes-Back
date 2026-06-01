using FastEndpoints;
using FluentValidation;
using PyroFetes.DTO.User.Request;

namespace PyroFetes.Validators.Users;

public class ConnectUserDtoValidator : Validator<ConnectUserDto>
{
    public ConnectUserDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Username is required")
            .MaximumLength(50)
            .WithMessage("Username cannot exceed 50 characters")
            .MinimumLength(2)
            .WithMessage("Username must exceed 2 characters");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Password is required");
    }
}