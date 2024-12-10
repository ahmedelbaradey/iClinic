using iClinic.Application.Base;
using iClinic.Application.Features.ClinicDepartments.Queries.Responses;
using MediatR;

namespace iClinic.Application.Features.ClinicDepartments.Queries.Models
{
    public class GetClinicDepartmentListQuery : IRequest<BaseResponse<List<GetClinicDepartmentResponse>>>
    {

    }
}
