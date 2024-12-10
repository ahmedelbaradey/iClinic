﻿using iClinic.Application.Base;


namespace iClinic.Application.Features.Doctors.Commands.Handlers.AddDoctor
{
 
    public record AddDoctorCommand : ICommand<BaseResponse<string>>
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Phone { get; set; }
        public bool Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsActive { get; set; }
    }
}
