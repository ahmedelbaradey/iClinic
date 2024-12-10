using iClinic.Application.Base;
using MediatR;

namespace iClinic.Application.Features.Patients.Commands.Models
{
    public class DeletePatientCommand : IRequest<BaseResponse<string>>
    {
        public int Id { get; set; }
        public DeletePatientCommand(int id)
        {
            Id = id;
        }
    }
}
