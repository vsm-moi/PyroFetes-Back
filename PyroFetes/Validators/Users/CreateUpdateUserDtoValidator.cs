using FastEndpoints;
using FluentValidation;
using PyroFetes.DTO.User.Request;

namespace PyroFetes.Validators.Users;

public class CreateUpdateUserDtoValidator: Validator<UpdateUserDto>
{
    public CreateUpdateUserDtoValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("L'email est requis")
            .MaximumLength(100)
            .WithMessage("L'email ne doit pas dépasser plus de 100 caractères")
            .EmailAddress()
            .WithMessage("Adresse email invalide");
        
        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Le mot de passe est requis")
            .MinimumLength(12)
            .WithMessage("Le mot de passe doit contenir au minimum 12 caractères")
            .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*?[#?_!@$%^&*-])");
    }
}