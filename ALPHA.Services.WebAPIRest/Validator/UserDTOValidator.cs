using ALPHA.Application.DTO;
using FluentValidation;

namespace ALPHA.Services.WebAPIRest.Validator
{
    public class UserDTOValidator : AbstractValidator<UserDTO>
    {
        public UserDTOValidator()
        {
            RuleFor(x => x.Names).NotEmpty().Length(5, 50)
                .WithMessage("Por favor especifíque los nombres del usuario.");

            RuleFor(x => x.Surnames).NotEmpty().Length(5, 120)
                .WithMessage("Por favor especifíque los apellidos del usuario.");

            RuleFor(x => x.Username).NotEmpty().Length(3, 120)
                .WithMessage("Por favor especifíque el nombre de usuario.");

            RuleFor(x => x.Password).NotEmpty().MinimumLength(3)
                .WithMessage("Por favor especifíque una contraseña.");

            RuleFor(x => x.Email).NotEmpty().Length(5, 150)
                .WithMessage("Por favor especifíque un correo electrónico.");
            
        }
    }
}
