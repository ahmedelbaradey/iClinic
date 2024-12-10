using iClinic.Application.Base;
using iClinic.Application.Features.Patients.Queries.Responses;
using MediatR;

namespace iClinic.Application.Features.Patients.Queries.Models
{
    public class GetPatientsListQuery : IRequest<BaseResponse<List<GetPatientsListResponse>>>
    {

    }
}
