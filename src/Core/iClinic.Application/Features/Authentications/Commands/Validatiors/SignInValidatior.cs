using FluentValidation;
using iClinic.Application.Features.Authentications.Commands.Handlers.SignIn;

namespace iClinic.Application.Features.Authentications.Commands.Validatiors
{
    public class SignInValidatior : AbstractValidator<SignInCommand>
    {

        public SignInValidatior()
        {
            ApplyValidationsRules();
        }

        #region Functions
        public void ApplyValidationsRules()
        {

            RuleFor(x => x.UserName)
                 .NotEmpty().WithMessage("Can't be empty.")
                 .NotNull().WithMessage("Can't be empty.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Can't be empty.")
                .NotNull().WithMessage("Can't be empty.");
        }
        #endregion
    }
}
