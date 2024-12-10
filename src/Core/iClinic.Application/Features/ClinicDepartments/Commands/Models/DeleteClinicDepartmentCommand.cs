using iClinic.Application.Base;
using MediatR;

namespace iClinic.Application.Features.ClinicDepartments.Commands.Models
{
    public class DeleteClinicDepartmentCommand : IRequest<BaseResponse<string>>
    {
        public int Id { get; set; }
        public DeleteClinicDepartmentCommand(int id)
        {
            Id = id;
        }
    }
}
