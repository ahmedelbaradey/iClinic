using iClinic.Application.Base;
using iClinic.Application.Features.ClinicDepartments.Queries.Responses;
using MediatR;

namespace iClinic.Application.Features.ClinicDepartments.Queries.Models
{
    public class GetClinicDepartmentByNameQuery : IRequest<BaseResponse<GetClinicDepartmentResponse>>
    {
        public string DepartmentName { get; set; } = null!;
        public GetClinicDepartmentByNameQuery(string departmentName)
        {
            DepartmentName = departmentName;
        }
    }
}
