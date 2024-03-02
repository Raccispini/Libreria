using FluentValidation;
using Libreria.Application.Models.Requests;

namespace Libreria.Application.Services.Validators
{
    public class SignUpRequestValidator : AbstractValidator<SignUpRequest>
    {
        public SignUpRequestValidator()
        {
            RuleFor(x => x.username).NotEmpty().NotNull()
                .WithMessage("Username non valido");
            RuleFor(x=>x.password).NotEmpty().NotNull()
                .WithMessage("Password non valida");
           

        }

    }
}
