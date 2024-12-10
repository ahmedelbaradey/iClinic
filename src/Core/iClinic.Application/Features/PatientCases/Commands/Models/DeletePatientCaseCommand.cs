using iClinic.Application.Base;
using MediatR;

namespace iClinic.Application.Features.PatientCases.Commands.Models
{
    public class DeletePatientCaseCommand : IRequest<BaseResponse<string>>
    {
        public int Id { get; set; }
        public DeletePatientCaseCommand(int id)
        {
            Id = id;
        }
    }
}
