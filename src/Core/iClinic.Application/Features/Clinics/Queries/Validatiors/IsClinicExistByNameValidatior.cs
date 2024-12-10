using iClinic.Application.Features.Clinics.Queries.Models;
using FluentValidation;

namespace iClinic.Application.Features.Clinics.Queries.Validatiors
{
    public class IsClinicExistByNameValidatior : AbstractValidator<IsClinicExistByNameQuery>
    {

        public IsClinicExistByNameValidatior()
        {
            ApplyValidationsRules();
        }

        public void ApplyValidationsRules()
        {

            RuleFor(x => x.ClinicName)
                .NotEmpty().WithMessage("Can't be empty.")
                .NotNull().WithMessage("Can't be blank.")
                .MaximumLength(500);
        }
    }
}
