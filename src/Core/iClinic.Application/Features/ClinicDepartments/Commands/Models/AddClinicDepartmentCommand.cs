using iClinic.Application.Base;
using MediatR;

namespace iClinic.Application.Features.ClinicDepartments.Commands.Models
{
    public class AddClinicDepartmentCommand : IRequest<BaseResponse<string>>
    {
        public string DepartmentName { get; set; } = null!;
        public string? Description { get; set; }
        public int ClinicId { get; set; }
    }
}
