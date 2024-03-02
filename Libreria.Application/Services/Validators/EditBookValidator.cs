using FluentValidation;
using FluentValidation.Results;
using Libreria.Application.Models.Requests;

namespace Libreria.Application.Services.Validators
{
    public class EditBookValidator : AbstractValidator<EditBookRequest>
    {
        public EditBookValidator()
        {
            RuleFor(x=>x.id).NotNull().NotEmpty()
                .WithMessage("id is required");
        }
    }
}
