﻿using iClinic.Application.Features.Patients.Commands.Models;
using  iClinic.Application.Abstracts.Presistence;
using FluentValidation;

namespace iClinic.Application.Features.Patients.Commands.Validatiors
{
    public class AddPatientValidatior : AbstractValidator<AddPatientCommand>
    {
        #region Fileds
        private readonly IPatientService _patientService;

        #endregion

        #region Constructor(s)
        public AddPatientValidatior(IPatientService patientService)
        {
            _patientService = patientService;
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }

        #endregion

        #region Functions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("Can't be empty.")
                .NotNull().WithMessage("Can't be blank.")
                .MaximumLength(150);

            RuleFor(x => x.LastName)
               .NotEmpty().WithMessage("Can't be empty.")
               .NotNull().WithMessage("Can't be blank.")
               .MaximumLength(150);

            RuleFor(x => x.Email)
               .NotEmpty().WithMessage("Can't be empty.")
               .NotNull().WithMessage("Can't be blank.")
               .MaximumLength(250);


            RuleFor(x => x.Gender)
             //.NotEmpty().WithMessage("Can't be empty.")
             .NotNull().WithMessage("Can't be blank.");

            RuleFor(x => x.DateOfBirth)
             .NotEmpty().WithMessage("Can't be empty.")
             .NotNull().WithMessage("Can't be blank.");
        }

        public void ApplyCustomValidationsRules()
        {
            RuleFor(x => x.Email)
                .MustAsync(async (key, CancellationToken) => !await _patientService.IsEmailExist(key))
                .WithMessage("already Exist.");
        }
        #endregion
    }
}
