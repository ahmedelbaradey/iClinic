using FluentValidation;
using iClinic.Application.Features.Authentications.Commands.Handlers.RefreshToken;

namespace iClinic.Application.Features.Authentications.Commands.Validatiors
{
    public class RefreshTokenValidatior : AbstractValidator<RefreshTokenCommand>
    {
        public RefreshTokenValidatior()
        {
            ApplyValidationsRules();
        }

        #region Functions
        public void ApplyValidationsRules()
        {

            RuleFor(x => x.AccessToken)
                 .NotNull().WithMessage("Can't be empty.")
                 .NotEmpty().WithMessage("Can't be empty.");

            RuleFor(x => x.RefreshToken)
                 .NotNull().WithMessage("Can't be empty.")
                 .NotEmpty().WithMessage("Can't be empty.");
        }
        #endregion
    }
}
