using FluentValidation;
using Libreria.Application.Models.Requests;

namespace Libreria.Application.Services.Validators
{
    public class FindBookRequestValidator : AbstractValidator<FindBookRequest>
    {
        public FindBookRequestValidator()
        {
            RuleFor(x => x.pageCount)
                .NotNull()
                .NotEmpty()
                .GreaterThanOrEqualTo(0)
                .WithMessage("Valore pageCount non valido");
            RuleFor(x => x.pageSize)
                .NotNull()
                .NotEmpty()
                .GreaterThan(1)
                .WithMessage("Valore pageSize non valido");
        }
    }
}
