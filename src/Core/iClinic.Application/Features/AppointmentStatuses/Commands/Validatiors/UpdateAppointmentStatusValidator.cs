﻿using iClinic.Application.Features.AppointmentStatuses.Commands.Models;
using FluentValidation;

namespace iClinic.Application.Features.AppointmentStatuses.Commands.Validatiors
{
    public class UpdateAppointmentStatusValidator : AbstractValidator<UpdateAppointmentStatusCommand>
    {

        public UpdateAppointmentStatusValidator()
        {
            ApplyValidationsRules();
        }
        #region Functions
        public void ApplyValidationsRules()
        {

            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Can't be empty.")
                .NotNull().WithMessage("Can't be blank.");

            RuleFor(x => x.statusName)
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
