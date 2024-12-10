﻿using iClinic.Application.Features.AppointmentStatuses.Commands.Models;
using FluentValidation;

namespace iClinic.Application.Features.AppointmentStatuses.Commands.Validatiors
{
    public class AddAppointmentStatusValidator : AbstractValidator<AddAppointmentStatusCommand>
    {


        public AddAppointmentStatusValidator()
        {
            ApplyValidationsRules();
        }

        #region Functions
        public void ApplyValidationsRules()
        {

            RuleFor(x => x.StatusName)
                .NotEmpty().WithMessage("Can't be empty.")
                .NotNull().WithMessage("Can't be blank.")
                .MaximumLength(100);

        }

        public void ApplyCustomValidationsRules()
        {

        }
        #endregion
    }
}
