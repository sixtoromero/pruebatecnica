using ALPHA.Application.DTO;
using FluentValidation;

namespace ALPHA.Services.WebAPIRest.Validator
{
    public class CorrespondenceDTOValidator : AbstractValidator<CorrespondenceDTO>
    {
        public CorrespondenceDTOValidator()
        {
            RuleFor(x => x.Type).NotEmpty().Length(2, 2)
                .WithMessage("Por favor especifíque el tipo de la correspondencia.");
            
            RuleFor(x => x.Subject).NotEmpty().Length(5, 80)
                .WithMessage("El asunto es requerido");

            RuleFor(x => x.Body).NotEmpty().MinimumLength(5)
                .WithMessage("El cuerpo del mensaje es requerido");
        }
    }
}
