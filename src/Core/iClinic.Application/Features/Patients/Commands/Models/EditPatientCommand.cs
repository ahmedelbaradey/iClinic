using iClinic.Application.Base;
using MediatR;

namespace iClinic.Application.Features.Patients.Commands.Models
{
    public class EditPatientCommand : IRequest<BaseResponse<string>>
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Phone { get; set; }
        public bool Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
