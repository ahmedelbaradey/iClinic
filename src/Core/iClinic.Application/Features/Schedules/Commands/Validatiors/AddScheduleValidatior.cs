﻿using iClinic.Application.Features.Schedules.Commands.Models;
using  iClinic.Application.Abstracts.Presistence;
using FluentValidation;

namespace iClinic.Application.Features.Schedules.Commands.Validatiors
{
    public class AddScheduleValidatior : AbstractValidator<AddScheduleCommand>
    {
        #region Fileds
        private readonly IEmployeeScheduleService _employeeScheduleService;

        #endregion

        #region Constructor(s)
        public AddScheduleValidatior(IEmployeeScheduleService employeeScheduleService)
        {
            _employeeScheduleService = employeeScheduleService;
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }

        #endregion

        #region Functions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Date)
                .NotEmpty().WithMessage("Can't be empty.")
                .NotNull().WithMessage("Can't be blank.");

            RuleFor(x => x.TimeStart)
               .NotEmpty().WithMessage("Can't be empty.")
               .NotNull().WithMessage("Can't be blank.");

            RuleFor(x => x.TimeEnd)
               .NotEmpty().WithMessage("Can't be empty.")
               .NotNull().WithMessage("Can't be blank.");


            RuleFor(x => x.EmployeeSchedulesId)
              .NotEmpty().WithMessage("Can't be empty.")
             .NotNull().WithMessage("Can't be blank.");


        }

        public void ApplyCustomValidationsRules()
        {
            RuleFor(x => x.EmployeeSchedulesId)
                .MustAsync(async (key, CancellationToken) => await _employeeScheduleService.IsEmployeeScheduleExist(key))
                .WithMessage(": EmployeeSchedules with this Id not exist.");

        }

        #endregion
    }
}
