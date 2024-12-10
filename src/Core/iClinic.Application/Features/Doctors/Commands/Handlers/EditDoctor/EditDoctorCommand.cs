using iClinic.Application.Base;
using iClinic.Application.Features.Doctors.Commands.Base;


namespace iClinic.Application.Features.Doctors.Commands.Handlers.EditDoctor
{
    public record EditDoctorCommand : BaseDoctorCommand, ICommand<BaseResponse<string>>
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
