﻿using  iClinic.Application.Abstracts.Presistence;
using FluentValidation;
using iClinic.Application.Features.Doctors.Commands.Handlers.AddDoctor;

namespace iClinic.Application.Features.Doctors.Commands.Validatiors
{
    public class AddDoctorValidatior : AbstractValidator<AddDoctorCommand>
    {
        #region Fileds
        private readonly IDoctorService _doctorService;

        #endregion

        #region Constructor(s)
        public AddDoctorValidatior(IDoctorService doctorService)
        {
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
            _doctorService = doctorService;
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
             .NotNull().WithMessage("Can't be blank.");

            RuleFor(x => x.DateOfBirth)
             .NotEmpty().WithMessage("Can't be empty.")
             .NotNull().WithMessage("Can't be blank.");

            RuleFor(x => x.IsActive)
            .NotNull().WithMessage("Can't be blank.");
        }

        public void ApplyCustomValidationsRules()
        {
            RuleFor(x => x.Email)
                .MustAsync(async (key, CancellationToken) => !await _doctorService.IsEmailExist(key))
                .WithMessage("{PropertyName} already Exist.");
        }

        #endregion
    }
}
