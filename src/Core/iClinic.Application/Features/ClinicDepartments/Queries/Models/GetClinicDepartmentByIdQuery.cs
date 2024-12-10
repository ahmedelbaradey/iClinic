using iClinic.Application.Base;
using iClinic.Application.Features.ClinicDepartments.Queries.Responses;
using MediatR;

namespace iClinic.Application.Features.ClinicDepartments.Queries.Models
{
    public class GetClinicDepartmentByIdQuery : IRequest<BaseResponse<GetClinicDepartmentResponse>>
    {

        public int Id { get; set; }

        public GetClinicDepartmentByIdQuery(int id)
        {
            Id = id;
        }
    }
}
