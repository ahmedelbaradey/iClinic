using iClinic.Application.Base;
using MediatR;

namespace iClinic.Application.Features.Patients.Commands.Models
{
    public class AddPatientCommand : IRequest<BaseResponse<string>>
    {

        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Phone { get; set; }
        public bool Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
