using iClinic.Application.Base;
using iClinic.Application.Features.PatientCases.Queries.Responses;
using MediatR;

namespace iClinic.Application.Features.PatientCases.Queries.Models
{
    public class GetPatientCaseListQuery : IRequest<BaseResponse<List<GetPatientCaseListResponse>>>
    {


    }
}
