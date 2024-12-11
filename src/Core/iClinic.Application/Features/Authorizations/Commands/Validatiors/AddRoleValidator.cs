using FluentValidation;
using iClinic.Application.Features.Authorizations.Commands.Handlers.AddRole;

namespace iClinic.Application.Features.Authorizations.Commands.Validatiors
{
    public class AddRoleValidator : AbstractValidator<AddRoleCommand>
    {

        #region Constructors
        public AddRoleValidator()
        {
            ApplyValidationsRules();
        }
        #endregion

        #region Handle Fnctions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.roleName)
                .NotNull().WithMessage("Can't be balnk.");
        }
        #endregion
    }
}
