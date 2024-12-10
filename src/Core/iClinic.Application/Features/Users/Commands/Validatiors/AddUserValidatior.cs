﻿using iClinic.Application.Features.Users.Commands.Models;
using FluentValidation;

namespace iClinic.Application.Features.Users.Commands.Validatiors
{
    public class AddUserValidatior : AbstractValidator<AddUserCommand>
    {

        #region Constructors
        public AddUserValidatior()
        {
            ApplyValidationsRules();
        }
        #endregion

        #region Functions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("Can't be empty.")
                .NotNull().WithMessage("Can't be blank.")
                .MaximumLength(200);

            RuleFor(x => x.UserName)
               .NotEmpty().WithMessage("Can't be empty.")
               .NotNull().WithMessage("Can't be blank.")
               .MaximumLength(100);

            RuleFor(x => x.Email)
               .NotEmpty().WithMessage("Can't be empty.")
               .NotNull().WithMessage("Can't be blank.")
               .MaximumLength(100);

            RuleFor(x => x.Password)
               .NotEmpty().WithMessage("Can't be empty.")
               .NotNull().WithMessage("Can't be blank.");

            RuleFor(x => x.ConfirmPassword)
               .NotEmpty().WithMessage("Can't be empty.")
               .NotNull().WithMessage("Can't be blank.")
               .Equal(x => x.Password).WithMessage("Password And Confirm Password not Equals.");

        }
        #endregion
    }
}
