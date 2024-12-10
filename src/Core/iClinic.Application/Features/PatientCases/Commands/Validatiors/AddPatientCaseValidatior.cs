﻿using iClinic.Application.Features.PatientCases.Commands.Models;
using  iClinic.Application.Abstracts.Presistence;
using FluentValidation;

namespace iClinic.Application.Features.PatientCases.Commands.Validatiors
{
    public class AddPatientCaseValidatior : AbstractValidator<AddPatientCaseCommand>
    {
        #region Fileds
        private readonly IPatientService _patientService;
        #endregion

        #region Constructors

        public AddPatientCaseValidatior(IPatientService patientService)
        {
            _patientService = patientService;
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }

        #endregion
        #region Functions
        public void ApplyValidationsRules()
        {

            RuleFor(x => x.PatientId)
                .NotEmpty().WithMessage("Can't be empty.")
                .NotNull().WithMessage("Can't be blank.");

            RuleFor(x => x.StartTime)
                .NotEmpty().WithMessage("Can't be empty.")
                .NotNull().WithMessage("Can't be blank.");

            RuleFor(x => x.InProgress)
                .NotNull().WithMessage("Can't be empty.");

            RuleFor(x => x.AmountPaid)
                .NotNull().WithMessage("Can't be empty.");

            RuleFor(x => x.TotalCost)
                .NotNull().WithMessage("Can't be empty.");
        }

        public void ApplyCustomValidationsRules()
        {
            RuleFor(x => x.PatientId)
                .MustAsync(async (key, CancellationToken) => await _patientService.IsPatientExistById(key))
                .WithMessage(": not found patient with this Id.");
        }
        #endregion
    }
}
